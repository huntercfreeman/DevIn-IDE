using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.Menus.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Dropdowns.Models;

namespace DevIn.Ide.RazorLib.CodeSearches.Displays;

public partial class CodeSearchContextMenu : ComponentBase
{
	[Parameter, EditorRequired]
	public TreeViewCommandArgs TreeViewCommandArgs { get; set; }

	public static readonly Key<DropdownRecord> ContextMenuEventDropdownKey = Key<DropdownRecord>.NewKey();

	private (TreeViewCommandArgs treeViewCommandArgs, MenuRecord menuRecord) _previousGetMenuRecordInvocation;
	
	private MenuRecord GetMenuRecord(TreeViewCommandArgs commandArgs)
    {
		if (_previousGetMenuRecordInvocation.treeViewCommandArgs == commandArgs)
			return _previousGetMenuRecordInvocation.menuRecord;

		if (commandArgs.TreeViewContainer.SelectedNodeList.Count > 1)
		{
			return GetMultiSelectionMenuRecord(commandArgs);
		}

        if (commandArgs.NodeThatReceivedMouseEvent is null)
		{
			var menuRecord = new MenuRecord(MenuRecord.NoMenuOptionsExistList);
			_previousGetMenuRecordInvocation = (commandArgs, menuRecord);
			return menuRecord;
		}

        var menuRecordsList = new List<MenuOptionRecord>();

        if (!menuRecordsList.Any())
		{
			var menuRecord = new MenuRecord(MenuRecord.NoMenuOptionsExistList);
			_previousGetMenuRecordInvocation = (commandArgs, menuRecord);
			return menuRecord;
		}

		// Default case
		{
			var menuRecord = new MenuRecord(menuRecordsList);
			_previousGetMenuRecordInvocation = (commandArgs, menuRecord);
			return menuRecord;
		}
    }

	private MenuRecord GetMultiSelectionMenuRecord(TreeViewCommandArgs commandArgs)
	{
		var menuOptionRecordList = new List<MenuOptionRecord>();

		if (!menuOptionRecordList.Any())
		{
			var menuRecord = new MenuRecord(MenuRecord.NoMenuOptionsExistList);
			_previousGetMenuRecordInvocation = (commandArgs, menuRecord);
			return menuRecord;
		}

		// Default case
		{
			var menuRecord = new MenuRecord(menuOptionRecordList);
			_previousGetMenuRecordInvocation = (commandArgs, menuRecord);
			return menuRecord;
		}
	}
}