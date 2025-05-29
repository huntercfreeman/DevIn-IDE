using Microsoft.AspNetCore.Components;

namespace DevIn.TextEditor.RazorLib.TextEditors.Displays.Internals;

public partial class LabelWidgetInlineDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public string Text { get; set; } = null!;
}