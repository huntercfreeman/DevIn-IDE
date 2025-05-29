using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.TreeViews.Models.Utils;

namespace DevIn.Common.RazorLib.TreeViews.Displays.Utils;

public partial class TreeViewGroupDisplay : ComponentBase
{
	[Parameter, EditorRequired]
	public TreeViewGroup TreeViewGroup { get; set; } = null!;
}