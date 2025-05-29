using DevIn.Extensions.CompilerServices.GenericLexer.SyntaxEnums;
using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.Extensions.CompilerServices.GenericLexer.SyntaxObjects;

public class GenericKeywordSyntax : IGenericSyntax
{
	public GenericKeywordSyntax(TextEditorTextSpan textSpan)
	{
		TextSpan = textSpan;
	}

	public TextEditorTextSpan TextSpan { get; }
	public IReadOnlyList<IGenericSyntax> ChildList => Array.Empty<IGenericSyntax>();
	public GenericSyntaxKind GenericSyntaxKind => GenericSyntaxKind.Keyword;
}