using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.CompilerServices.Xml.Html.SyntaxEnums;

namespace DevIn.CompilerServices.Xml.Html.SyntaxObjects;

public class InjectedLanguageFragmentNode : IHtmlSyntaxNode
{
    public InjectedLanguageFragmentNode(
		IReadOnlyList<IHtmlSyntax> childHtmlSyntaxes,
        TextEditorTextSpan textEditorTextSpan)
    {
        TextEditorTextSpan = textEditorTextSpan;

        ChildContent = childHtmlSyntaxes;
        Children = ChildContent;
    }

    public TextEditorTextSpan TextEditorTextSpan { get; }
    public IReadOnlyList<IHtmlSyntax> ChildContent { get; }
    public IReadOnlyList<IHtmlSyntax> Children { get; }

    public HtmlSyntaxKind HtmlSyntaxKind => HtmlSyntaxKind.InjectedLanguageFragmentNode;
}