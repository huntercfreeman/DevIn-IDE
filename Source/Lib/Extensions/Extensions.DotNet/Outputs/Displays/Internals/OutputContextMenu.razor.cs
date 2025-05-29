using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Dropdowns.Models;
using DevIn.Common.RazorLib.Commands.Models;

namespace DevIn.Extensions.DotNet.Outputs.Displays.Internals;

public partial class OutputContextMenu : ComponentBase
{
	[Parameter, EditorRequired]
	public TreeViewCommandArgs TreeViewCommandArgs { get; set; }

	public static readonly Key<DropdownRecord> ContextMenuEventDropdownKey = Key<DropdownRecord>.NewKey();
}