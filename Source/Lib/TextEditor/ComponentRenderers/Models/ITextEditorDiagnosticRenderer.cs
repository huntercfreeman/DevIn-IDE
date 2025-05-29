using DevIn.TextEditor.RazorLib.CompilerServices;

namespace DevIn.TextEditor.RazorLib.ComponentRenderers.Models;

public interface ITextEditorDiagnosticRenderer
{
    public TextEditorDiagnostic Diagnostic { get; set; }
}