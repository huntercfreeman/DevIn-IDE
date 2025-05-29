using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Ide.RazorLib.BackgroundTasks.Models;

namespace DevIn.Extensions.DotNet.CompilerServices.Models;

public class CompilerServiceExplorerTreeViewMouseEventHandler : TreeViewMouseEventHandler
{
	private readonly IdeBackgroundTaskApi _ideBackgroundTaskApi;

	public CompilerServiceExplorerTreeViewMouseEventHandler(
			IdeBackgroundTaskApi ideBackgroundTaskApi,
			ITreeViewService treeViewService,
			BackgroundTaskService backgroundTaskService)
		: base(treeViewService, backgroundTaskService)
	{
		_ideBackgroundTaskApi = ideBackgroundTaskApi;
	}

	public override Task OnDoubleClickAsync(TreeViewCommandArgs commandArgs)
	{
		return base.OnDoubleClickAsync(commandArgs);
	}
}