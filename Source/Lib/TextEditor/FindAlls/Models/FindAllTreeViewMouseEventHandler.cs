using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib.Installations.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;

namespace DevIn.TextEditor.RazorLib.FindAlls.Models;

public class FindAllTreeViewMouseEventHandler : TreeViewMouseEventHandler
{
	private readonly TextEditorService _textEditorService;
	private readonly DevInTextEditorConfig _textEditorConfig;
	private readonly IServiceProvider _serviceProvider;

	public FindAllTreeViewMouseEventHandler(
			TextEditorService textEditorService,
			DevInTextEditorConfig textEditorConfig,
			IServiceProvider serviceProvider,
			ITreeViewService treeViewService,
			BackgroundTaskService backgroundTaskService)
		: base(treeViewService, backgroundTaskService)
	{
		_textEditorService = textEditorService;
		_textEditorConfig = textEditorConfig;
		_serviceProvider = serviceProvider;
	}

	public override Task OnDoubleClickAsync(TreeViewCommandArgs commandArgs)
	{
		base.OnDoubleClickAsync(commandArgs);

		if (commandArgs.NodeThatReceivedMouseEvent is not TreeViewFindAllTextSpan treeViewFindAllTextSpan)
			return Task.CompletedTask;

		_textEditorService.WorkerArbitrary.PostUnique(async editContext =>
    	{
    		await _textEditorService.OpenInEditorAsync(
    			editContext,
    			treeViewFindAllTextSpan.AbsolutePath.Value,
				true,
				treeViewFindAllTextSpan.Item.StartInclusiveIndex,
				new Category("main"),
				Key<TextEditorViewModel>.NewKey());
    	});
    	return Task.CompletedTask;
	}
}