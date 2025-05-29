using Microsoft.AspNetCore.Components;

namespace DevIn.Common.RazorLib.TreeViews.Displays.Utils;

public partial class TreeViewMarkupStringDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public MarkupString MarkupString { get; set; }
}