using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices.Syntax;

namespace DevIn.Extensions.CompilerServices;

public class ExtendedCompilationUnit : ICompilationUnit
{
	public IReadOnlyList<SyntaxToken> TokenList { get; init; } = Array.Empty<SyntaxToken>();
	public IReadOnlyList<TextEditorDiagnostic> DiagnosticList { get; init; } = Array.Empty<TextEditorDiagnostic>();

	public IEnumerable<TextEditorTextSpan> GetTextTextSpans()
	{
		return TokenList.Select(x => x.TextSpan);
	}

	public IEnumerable<TextEditorTextSpan> GetDiagnosticTextSpans()
	{
		return DiagnosticList.Select(x => x.TextSpan);
	}
}
