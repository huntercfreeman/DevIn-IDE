using DevIn.TextEditor.RazorLib.Diffs.Models;
using Microsoft.AspNetCore.Components;

namespace DevIn.TextEditor.RazorLib.Diffs.Displays.Internals;

public partial class DiffDetailsInTextDisplay : ComponentBase
{
    [CascadingParameter]
    public TextEditorDiffResult DiffResult { get; set; } = null!;
}
