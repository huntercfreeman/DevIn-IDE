/*
// FindAllReferences
using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.TextEditor.RazorLib;
using DevIn.TextEditor.RazorLib.Installations.Models;

namespace DevIn.Ide.RazorLib.FindAllReferences.Models;

public class FindAllReferencesTreeViewMouseEventHandler : TreeViewMouseEventHandler
{
	private readonly ITextEditorService _textEditorService;
	private readonly DevInTextEditorConfig _textEditorConfig;
	private readonly IServiceProvider _serviceProvider;

	public FindAllReferencesTreeViewMouseEventHandler(
			ITextEditorService textEditorService,
			DevInTextEditorConfig textEditorConfig,
			IServiceProvider serviceProvider,
			ITreeViewService treeViewService,
			IBackgroundTaskService backgroundTaskService)
		: base(treeViewService, backgroundTaskService)
	{
		_textEditorService = textEditorService;
		_textEditorConfig = textEditorConfig;
		_serviceProvider = serviceProvider;
	}

	public override Task OnDoubleClickAsync(TreeViewCommandArgs commandArgs)
	{
		base.OnDoubleClickAsync(commandArgs);

		if (commandArgs.NodeThatReceivedMouseEvent is not TreeViewFindAllReferences treeViewFindAllReferences)
			return Task.CompletedTask;
			
		return FindAllReferencesTextSpanHelper.OpenInEditorOnClick(
			treeViewFindAllReferences,
			true,
			_textEditorService);
	}
}
*/