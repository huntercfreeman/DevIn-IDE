using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.TextEditor.RazorLib.ComponentRenderers.Models;
using Microsoft.AspNetCore.Components;

namespace DevIn.TextEditor.RazorLib.TextEditors.Displays.Internals;

public partial class DiagnosticDisplay : ComponentBase, ITextEditorDiagnosticRenderer
{
    [Parameter, EditorRequired]
    public TextEditorDiagnostic Diagnostic { get; set; } = default!;
}