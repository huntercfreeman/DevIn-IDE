using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib;
using DevIn.TextEditor.RazorLib.Installations.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;

namespace DevIn.Ide.RazorLib.CodeSearches.Models;

public class CodeSearchTreeViewMouseEventHandler : TreeViewMouseEventHandler
{
	private readonly TextEditorService _textEditorService;
	private readonly DevInTextEditorConfig _textEditorConfig;
	private readonly IServiceProvider _serviceProvider;

	public CodeSearchTreeViewMouseEventHandler(
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

		if (commandArgs.NodeThatReceivedMouseEvent is not TreeViewCodeSearchTextSpan treeViewCodeSearchTextSpan)
			return Task.CompletedTask;

		_textEditorService.WorkerArbitrary.PostUnique(async editContext =>
		{
			await _textEditorService.OpenInEditorAsync(
				editContext,
				treeViewCodeSearchTextSpan.AbsolutePath.Value,
				true,
				treeViewCodeSearchTextSpan.Item.StartInclusiveIndex,
				new Category("main"),
				Key<TextEditorViewModel>.NewKey());
		});
		return Task.CompletedTask;
	}
}
