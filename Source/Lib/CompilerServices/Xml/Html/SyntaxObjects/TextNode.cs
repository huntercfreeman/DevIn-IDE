using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.CompilerServices.Xml.Html.SyntaxEnums;

namespace DevIn.CompilerServices.Xml.Html.SyntaxObjects;

public class TextNode : IHtmlSyntaxNode
{
    public TextNode(TextEditorTextSpan textEditorTextSpan)
    {
        TextEditorTextSpan = textEditorTextSpan;

        ChildContent = Array.Empty<IHtmlSyntax>();
        Children = Array.Empty<IHtmlSyntax>();
    }

    public IReadOnlyList<IHtmlSyntax> ChildContent { get; }
    public IReadOnlyList<IHtmlSyntax> Children { get; }
    public TextEditorTextSpan TextEditorTextSpan { get; }

    public HtmlSyntaxKind HtmlSyntaxKind => HtmlSyntaxKind.TextNode;
}