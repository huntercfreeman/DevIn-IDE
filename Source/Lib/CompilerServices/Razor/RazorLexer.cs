using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices;
using DevIn.Extensions.CompilerServices.Syntax;
using DevIn.CompilerServices.CSharp.CompilerServiceCase;
using DevIn.CompilerServices.Razor.CompilerServiceCase;
using DevIn.CompilerServices.Razor.Facts;
using DevIn.CompilerServices.Xml.Html.InjectedLanguage;
using DevIn.CompilerServices.Xml.Html.SyntaxActors;

namespace DevIn.CompilerServices.Razor;

public class RazorLexer
{
    private readonly RazorCompilerService _razorCompilerService;
    private readonly CSharpCompilerService _cSharpCompilerService;
    private readonly IEnvironmentProvider _environmentProvider;

	private static readonly LexerKeywords LexerKeywords = LexerKeywords.Empty;
	
	private readonly StringWalker _stringWalker;
	
	private readonly List<SyntaxToken> _syntaxTokenList = new();
	
	public List<SyntaxToken> SyntaxTokenList => _syntaxTokenList;

    public RazorLexer(
        ResourceUri resourceUri,
        string sourceText,
        RazorCompilerService razorCompilerService,
        CSharpCompilerService cSharpCompilerService,
        IEnvironmentProvider environmentProvider)
    {
        _environmentProvider = environmentProvider;
        _razorCompilerService = razorCompilerService;
        _cSharpCompilerService = cSharpCompilerService;
        
        ResourceUri = resourceUri;
        SourceText = sourceText;

        RazorSyntaxTree = new RazorSyntaxTree(ResourceUri, _razorCompilerService, _cSharpCompilerService, _environmentProvider);
        
        _stringWalker = new(resourceUri, sourceText);
    }
    
    public ResourceUri ResourceUri { get; }
    public string SourceText { get; }

    public RazorSyntaxTree RazorSyntaxTree { get; private set; }

    public void Lex()
    {
        RazorSyntaxTree = new RazorSyntaxTree(ResourceUri, _razorCompilerService, _cSharpCompilerService, _environmentProvider);

        InjectedLanguageDefinition razorInjectedLanguageDefinition = new(
            RazorFacts.TRANSITION_SUBSTRING,
            RazorFacts.TRANSITION_SUBSTRING_ESCAPED,
            RazorSyntaxTree.ParseInjectedLanguageFragment,
            RazorSyntaxTree.ParseTagName,
            RazorSyntaxTree.ParseAttributeName,
            RazorSyntaxTree.ParseAttributeValue);

        var htmlSyntaxUnit = HtmlSyntaxTree.ParseText(
            ResourceUri,
            _stringWalker.SourceText,
            razorInjectedLanguageDefinition);

        var syntaxNodeRoot = htmlSyntaxUnit.RootTagSyntax;

        var htmlSyntaxWalker = new HtmlSyntaxWalker();

        htmlSyntaxWalker.Visit(syntaxNodeRoot);

        // Tag Names
        _syntaxTokenList.AddRange(
            htmlSyntaxWalker.TagNameNodes.Select(tns => new SyntaxToken(SyntaxKind.BadToken, tns.TextEditorTextSpan)));

        // InjectedLanguageFragmentSyntaxes
        _syntaxTokenList.AddRange(
            htmlSyntaxWalker.InjectedLanguageFragmentNodes.Select(ilfs => new SyntaxToken(SyntaxKind.BadToken, ilfs.TextEditorTextSpan)));

        // Attribute Names
        _syntaxTokenList.AddRange(
            htmlSyntaxWalker.AttributeNameNodes.Select(an => new SyntaxToken(SyntaxKind.BadToken, an.TextEditorTextSpan)));

        // Attribute Values
        _syntaxTokenList.AddRange(
            htmlSyntaxWalker.AttributeValueNodes.Select(av => new SyntaxToken(SyntaxKind.BadToken, av.TextEditorTextSpan)));

        // Comments
        _syntaxTokenList.AddRange(
            htmlSyntaxWalker.CommentNodes.Select(c => new SyntaxToken(SyntaxKind.BadToken, c.TextEditorTextSpan)));

        RazorSyntaxTree.ParseCodebehind();
    }
}