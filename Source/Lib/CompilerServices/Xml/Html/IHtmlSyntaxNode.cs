using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.CompilerServices.Xml.Html;

public interface IHtmlSyntaxNode : IHtmlSyntax
{
    public IReadOnlyList<IHtmlSyntax> ChildContent { get; }
    public IReadOnlyList<IHtmlSyntax> Children { get; }
    public TextEditorTextSpan TextEditorTextSpan { get; }
}