using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.TextEditor.RazorLib;
using DevIn.TextEditor.RazorLib.Installations.Models;

namespace DevIn.Extensions.DotNet.Outputs.Models;

public class OutputTreeViewMouseEventHandler : TreeViewMouseEventHandler
{
	private readonly TextEditorService _textEditorService;
	private readonly DevInTextEditorConfig _textEditorConfig;
	private readonly IServiceProvider _serviceProvider;

	public OutputTreeViewMouseEventHandler(
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

		if (commandArgs.NodeThatReceivedMouseEvent is not TreeViewDiagnosticLine treeViewDiagnosticLine)
			return Task.CompletedTask;
			
		return OutputTextSpanHelper.OpenInEditorOnClick(
			treeViewDiagnosticLine,
			true,
			_textEditorService);
	}
}
