using Microsoft.AspNetCore.Components;
using DevIn.TextEditor.RazorLib.FindAlls.Models;

namespace DevIn.TextEditor.RazorLib.FindAlls.Displays;

public partial class TreeViewFindAllGroupDisplay : ComponentBase
{
	[Parameter, EditorRequired]
	public TreeViewFindAllGroup TreeViewFindAllGroup { get; set; } = null!;
}