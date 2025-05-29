using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib.Diffs.Models;
using Microsoft.AspNetCore.Components;

namespace DevIn.TextEditor.RazorLib.Diffs.Displays;

public partial class DiffDetailsDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public Key<TextEditorDiffModel> DiffModelKey { get; set; } = Key<TextEditorDiffModel>.Empty;
    [Parameter, EditorRequired]
    public TextEditorDiffResult? DiffResult { get; set; } = null!;
}