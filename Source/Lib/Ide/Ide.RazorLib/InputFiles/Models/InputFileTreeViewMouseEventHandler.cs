using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Ide.RazorLib.FileSystems.Models;

namespace DevIn.Ide.RazorLib.InputFiles.Models;

public class InputFileTreeViewMouseEventHandler : TreeViewMouseEventHandler
{
    private readonly IInputFileService _inputFileService;
    private readonly Func<AbsolutePath, Task> _setInputFileContentTreeViewRootFunc;

    public InputFileTreeViewMouseEventHandler(
        ITreeViewService treeViewService,
        IInputFileService inputFileService,
        Func<AbsolutePath, Task> setInputFileContentTreeViewRootFunc,
		BackgroundTaskService backgroundTaskService)
        : base(treeViewService, backgroundTaskService)
    {
        _inputFileService = inputFileService;
        _setInputFileContentTreeViewRootFunc = setInputFileContentTreeViewRootFunc;
    }

    protected override void OnClick(TreeViewCommandArgs commandArgs)
    {
        base.OnClick(commandArgs);

        if (commandArgs.NodeThatReceivedMouseEvent is not TreeViewAbsolutePath treeViewAbsolutePath)
            return;

        _inputFileService.SetSelectedTreeViewModel(treeViewAbsolutePath);
    }

    public override Task OnDoubleClickAsync(TreeViewCommandArgs commandArgs)
    {
        base.OnDoubleClickAsync(commandArgs);

        if (commandArgs.NodeThatReceivedMouseEvent is not TreeViewAbsolutePath treeViewAbsolutePath)
            return Task.CompletedTask;

        _setInputFileContentTreeViewRootFunc.Invoke(treeViewAbsolutePath.Item);
        return Task.CompletedTask;
    }
}