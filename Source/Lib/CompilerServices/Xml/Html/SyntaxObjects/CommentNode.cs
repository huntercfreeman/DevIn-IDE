using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.CompilerServices.Xml.Html.SyntaxEnums;

namespace DevIn.CompilerServices.Xml.Html.SyntaxObjects;

public class CommentNode : IHtmlSyntaxNode
{
    public CommentNode(
        TextEditorTextSpan textEditorTextSpan)
    {
        TextEditorTextSpan = textEditorTextSpan;

        ChildContent = Array.Empty<IHtmlSyntax>();
        Children = Array.Empty<IHtmlSyntax>();
    }

    public TextEditorTextSpan TextEditorTextSpan { get; }
    public IReadOnlyList<IHtmlSyntax> ChildContent { get; }
    public IReadOnlyList<IHtmlSyntax> Children { get; }

    public HtmlSyntaxKind HtmlSyntaxKind => HtmlSyntaxKind.CommentNode;
}