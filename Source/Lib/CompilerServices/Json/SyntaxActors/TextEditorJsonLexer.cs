using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.RenderStates.Models;
using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices;
using DevIn.Extensions.CompilerServices.Syntax;

namespace DevIn.CompilerServices.Json.SyntaxActors;

public class TextEditorJsonLexer
{
	public static LexerKeywords LexerKeyWords = LexerKeywords.Empty;

    public TextEditorJsonLexer(ResourceUri resourceUri, string sourceText)
    {
    	ResourceUri = resourceUri;
    	SourceText = sourceText;
    }

    public Key<RenderState> ModelRenderStateKey { get; private set; } = Key<RenderState>.Empty;

	public ResourceUri ResourceUri { get; }
	public string SourceText { get; }
	public List<SyntaxToken> SyntaxTokenList { get; } = new();

    public void Lex()
    {
        var jsonSyntaxUnit = JsonSyntaxTree.ParseText(
            ResourceUri,
            SourceText);
        
        var syntaxNodeRoot = jsonSyntaxUnit.JsonDocumentSyntax;

        var syntaxWalker = new JsonSyntaxWalker();
        syntaxWalker.Visit(syntaxNodeRoot);

        SyntaxTokenList.AddRange(
            syntaxWalker.PropertyKeySyntaxes.Select(x => new SyntaxToken(SyntaxKind.BadToken, x.TextEditorTextSpan)));

        SyntaxTokenList.AddRange(
            syntaxWalker.BooleanSyntaxes.Select(x => new SyntaxToken(SyntaxKind.BadToken, x.TextEditorTextSpan)));

        SyntaxTokenList.AddRange(
            syntaxWalker.IntegerSyntaxes.Select(x => new SyntaxToken(SyntaxKind.BadToken, x.TextEditorTextSpan)));

        SyntaxTokenList.AddRange(
            syntaxWalker.NullSyntaxes.Select(x => new SyntaxToken(SyntaxKind.BadToken, x.TextEditorTextSpan)));

        SyntaxTokenList.AddRange(
            syntaxWalker.NumberSyntaxes.Select(x => new SyntaxToken(SyntaxKind.BadToken, x.TextEditorTextSpan)));

        SyntaxTokenList.AddRange(
            syntaxWalker.StringSyntaxes.Select(x => new SyntaxToken(SyntaxKind.BadToken, x.TextEditorTextSpan)));
    }
}