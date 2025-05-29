using DevIn.Extensions.CompilerServices.GenericLexer.SyntaxEnums;
using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.Extensions.CompilerServices.GenericLexer;

public interface IGenericSyntax
{
	public TextEditorTextSpan TextSpan { get; }
	public IReadOnlyList<IGenericSyntax> ChildList { get; }
	public GenericSyntaxKind GenericSyntaxKind { get; }
}