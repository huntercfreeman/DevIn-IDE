using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib;
using DevIn.TextEditor.RazorLib.TextEditors.Models;
using DevIn.Ide.RazorLib.BackgroundTasks.Models;
using DevIn.Extensions.DotNet.Namespaces.Models;

namespace DevIn.Extensions.DotNet.DotNetSolutions.Models;

public class SolutionExplorerTreeViewMouseEventHandler : TreeViewMouseEventHandler
{
	private readonly IdeBackgroundTaskApi _ideBackgroundTaskApi;
	private readonly TextEditorService _textEditorService;

	public SolutionExplorerTreeViewMouseEventHandler(
			IdeBackgroundTaskApi ideBackgroundTaskApi,
			TextEditorService textEditorService,
			ITreeViewService treeViewService,
			BackgroundTaskService backgroundTaskService)
		: base(treeViewService, backgroundTaskService)
	{
		_ideBackgroundTaskApi = ideBackgroundTaskApi;
		_textEditorService = textEditorService;
	}

	public override Task OnDoubleClickAsync(TreeViewCommandArgs commandArgs)
	{
		base.OnDoubleClickAsync(commandArgs);

		if (commandArgs.NodeThatReceivedMouseEvent is not TreeViewNamespacePath treeViewNamespacePath)
			return Task.CompletedTask;
		
		_textEditorService.WorkerArbitrary.PostUnique(async editContext =>
		{
			await _textEditorService.OpenInEditorAsync(
				editContext,
				treeViewNamespacePath.Item.AbsolutePath.Value,
				true,
				null,
				new Category("main"),
				Key<TextEditorViewModel>.NewKey());
		});
		return Task.CompletedTask;
	}
}