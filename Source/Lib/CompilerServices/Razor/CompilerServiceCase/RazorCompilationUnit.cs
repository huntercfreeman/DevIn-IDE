using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices.Syntax;

namespace DevIn.CompilerServices.Razor.CompilerServiceCase;

public class RazorCompilationUnit : ICompilationUnit
{
	public IReadOnlyList<SyntaxToken> TokenList { get; init; } = Array.Empty<SyntaxToken>();
	public RazorResource RazorResource { get; init; }
	public IReadOnlyList<TextEditorDiagnostic> DiagnosticList { get; init; } = Array.Empty<TextEditorDiagnostic>();

	public IEnumerable<TextEditorTextSpan> GetTextTextSpans()
	{
		return TokenList.Select(x => x.TextSpan)
			.Concat(RazorResource.GetSymbols().Select(x => x.TextSpan));
	}

	public IEnumerable<TextEditorTextSpan> GetDiagnosticTextSpans()
	{
		return DiagnosticList.Select(x => x.TextSpan);
	}
}
