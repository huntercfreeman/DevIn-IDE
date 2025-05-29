using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.CompilerServices.Css.SyntaxEnums;

namespace DevIn.CompilerServices.Css.SyntaxObjects;

public class CssCommentSyntax : ICssSyntax
{
    public CssCommentSyntax(
        TextEditorTextSpan textEditorTextSpan,
        IReadOnlyList<ICssSyntax> childCssSyntaxes)
    {
        ChildCssSyntaxes = childCssSyntaxes;
        TextEditorTextSpan = textEditorTextSpan;
    }

    public TextEditorTextSpan TextEditorTextSpan { get; }
    public IReadOnlyList<ICssSyntax> ChildCssSyntaxes { get; }

    public CssSyntaxKind CssSyntaxKind => CssSyntaxKind.Comment;
}