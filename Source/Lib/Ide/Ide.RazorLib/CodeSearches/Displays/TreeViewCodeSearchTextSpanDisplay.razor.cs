using Microsoft.AspNetCore.Components;
using DevIn.Ide.RazorLib.CodeSearches.Models;

namespace DevIn.Ide.RazorLib.CodeSearches.Displays;

public partial class TreeViewCodeSearchTextSpanDisplay : ComponentBase
{
	[Parameter, EditorRequired]
	public TreeViewCodeSearchTextSpan TreeViewCodeSearchTextSpan { get; set; } = null!;
}