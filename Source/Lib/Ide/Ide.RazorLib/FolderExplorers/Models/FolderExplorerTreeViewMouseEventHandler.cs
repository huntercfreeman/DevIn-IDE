using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib;
using DevIn.TextEditor.RazorLib.TextEditors.Models;
using DevIn.Ide.RazorLib.BackgroundTasks.Models;
using DevIn.Ide.RazorLib.FileSystems.Models;

namespace DevIn.Ide.RazorLib.FolderExplorers.Models;

public class FolderExplorerTreeViewMouseEventHandler : TreeViewMouseEventHandler
{
    private readonly IdeBackgroundTaskApi _ideBackgroundTaskApi;
    private readonly TextEditorService _textEditorService;

    public FolderExplorerTreeViewMouseEventHandler(
            IdeBackgroundTaskApi ideBackgroundTaskApi,
            TextEditorService textEditorService,
            ITreeViewService treeViewService,
		    BackgroundTaskService backgroundTaskService)
        : base(treeViewService, backgroundTaskService)
    {
        _ideBackgroundTaskApi = ideBackgroundTaskApi;
        _textEditorService = textEditorService;
    }

    public override async Task OnDoubleClickAsync(TreeViewCommandArgs commandArgs)
    {
        await base.OnDoubleClickAsync(commandArgs).ConfigureAwait(false);

        if (commandArgs.NodeThatReceivedMouseEvent is not TreeViewAbsolutePath treeViewAbsolutePath)
            return;

		_textEditorService.WorkerArbitrary.PostUnique(async editContext =>
		{
			await _textEditorService.OpenInEditorAsync(
				editContext,
				treeViewAbsolutePath.Item.Value,
				true,
				cursorPositionIndex: null,
				new Category("main"),
				Key<TextEditorViewModel>.NewKey());
		});
    }
}