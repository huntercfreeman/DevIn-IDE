using Microsoft.AspNetCore.Components.Web;
using DevIn.Common.RazorLib.JavaScriptObjects.Models;
using DevIn.Common.RazorLib.TreeViews.Models;

namespace DevIn.Common.RazorLib.Commands.Models;

/// <summary>
/// Verify that 'TreeViewService is not null' to know this was constructed rather than default.
/// </summary>
public record struct TreeViewCommandArgs : ICommandArgs
{
    public TreeViewCommandArgs(
        ITreeViewService treeViewService,
        TreeViewContainer treeViewContainer,
        TreeViewNoType? nodeThatReceivedMouseEvent,
        Func<Task> restoreFocusToTreeView,
        ContextMenuFixedPosition? contextMenuFixedPosition,
        MouseEventArgs? mouseEventArgs,
        KeyboardEventArgs? keyboardEventArgs)
    {
        TreeViewService = treeViewService;
        TreeViewContainer = treeViewContainer;
        NodeThatReceivedMouseEvent = nodeThatReceivedMouseEvent;
        RestoreFocusToTreeView = restoreFocusToTreeView;
        ContextMenuFixedPosition = contextMenuFixedPosition;
        MouseEventArgs = mouseEventArgs;
        KeyboardEventArgs = keyboardEventArgs;
    }

    public ITreeViewService TreeViewService { get; }
    public TreeViewContainer TreeViewContainer { get; }
    public TreeViewNoType? NodeThatReceivedMouseEvent { get; }
    public Func<Task> RestoreFocusToTreeView { get; }
    public ContextMenuFixedPosition? ContextMenuFixedPosition { get; }
    public MouseEventArgs? MouseEventArgs { get; }
    public KeyboardEventArgs? KeyboardEventArgs { get; }
}
