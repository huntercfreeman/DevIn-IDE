namespace DevIn.Common.RazorLib.BackgroundTasks.Models;

public enum CommonWorkKind
{
	None,
	DevInCommonInitializerWork,
    WriteToLocalStorage,
    Tab_ManuallyPropagateOnContextMenu,
    TreeView_HandleTreeViewOnContextMenu,
    TreeView_HandleExpansionChevronOnMouseDown,
    TreeView_ManuallyPropagateOnContextMenu,
    TreeViewService_LoadChildList,
}
