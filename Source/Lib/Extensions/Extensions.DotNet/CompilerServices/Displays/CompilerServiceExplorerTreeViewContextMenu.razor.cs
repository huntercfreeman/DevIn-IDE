using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.Dropdowns.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Menus.Models;

namespace DevIn.Extensions.DotNet.CompilerServices.Displays;

public partial class CompilerServiceExplorerTreeViewContextMenu : ComponentBase
{
	[Parameter, EditorRequired]
	public TreeViewCommandArgs TreeViewCommandArgs { get; set; }

	public static readonly Key<DropdownRecord> ContextMenuEventDropdownKey = Key<DropdownRecord>.NewKey();

	private MenuRecord GetMenuRecord(TreeViewCommandArgs treeViewCommandArgs)
	{
		// Suppress unused variable
		_ = treeViewCommandArgs;

		// Default case
		{
			return new MenuRecord(MenuRecord.NoMenuOptionsExistList);
		}
	}
}