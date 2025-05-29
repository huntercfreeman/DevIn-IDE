using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.TextEditor.RazorLib.CompilerServices;

public interface ICompilationUnit
{
	public IEnumerable<TextEditorTextSpan> GetTextTextSpans();
	public IEnumerable<TextEditorTextSpan> GetDiagnosticTextSpans();
}
