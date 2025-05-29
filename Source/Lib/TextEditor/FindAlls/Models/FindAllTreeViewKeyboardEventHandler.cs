using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.Keyboards.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib.Installations.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;

namespace DevIn.TextEditor.RazorLib.FindAlls.Models;

public class FindAllTreeViewKeyboardEventHandler : TreeViewKeyboardEventHandler
{
	private readonly TextEditorService _textEditorService;
	private readonly DevInTextEditorConfig _textEditorConfig;
	private readonly IServiceProvider _serviceProvider;

	public FindAllTreeViewKeyboardEventHandler(
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

	public override Task OnKeyDownAsync(TreeViewCommandArgs commandArgs)
	{
		if (commandArgs.KeyboardEventArgs is null)
			return Task.CompletedTask;

		base.OnKeyDownAsync(commandArgs);

		switch (commandArgs.KeyboardEventArgs.Code)
		{
			case KeyboardKeyFacts.WhitespaceCodes.ENTER_CODE:
				return InvokeOpenInEditor(commandArgs, true);
			case KeyboardKeyFacts.WhitespaceCodes.SPACE_CODE:
				return InvokeOpenInEditor(commandArgs, false);
		}
		
		return Task.CompletedTask;
	}

	private Task InvokeOpenInEditor(TreeViewCommandArgs commandArgs, bool shouldSetFocusToEditor)
	{
		var activeNode = commandArgs.TreeViewContainer.ActiveNode;

		if (activeNode is not TreeViewFindAllTextSpan treeViewFindAllTextSpan)
			return Task.CompletedTask;

		_textEditorService.WorkerArbitrary.PostUnique(async editContext =>
    	{
    		await _textEditorService.OpenInEditorAsync(
    			editContext,
				treeViewFindAllTextSpan.AbsolutePath.Value,
				shouldSetFocusToEditor,
				treeViewFindAllTextSpan.Item.StartInclusiveIndex,
				new Category("main"),
				Key<TextEditorViewModel>.NewKey());
    	});
		return Task.CompletedTask;
	}
}