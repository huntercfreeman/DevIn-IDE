using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.CompilerServices.Css.SyntaxEnums;

namespace DevIn.CompilerServices.Css;

public interface ICssSyntax
{
    public CssSyntaxKind CssSyntaxKind { get; }
    public TextEditorTextSpan TextEditorTextSpan { get; }
    public IReadOnlyList<ICssSyntax> ChildCssSyntaxes { get; }
}