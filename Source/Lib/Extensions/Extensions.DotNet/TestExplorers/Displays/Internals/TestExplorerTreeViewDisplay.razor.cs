using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.Dropdowns.Models;
using DevIn.Common.RazorLib.Notifications.Models;
using DevIn.Common.RazorLib.Dimensions.Models;
using DevIn.Common.RazorLib.ComponentRenderers.Models;
using DevIn.TextEditor.RazorLib;
using DevIn.Extensions.DotNet.TestExplorers.Models;
using DevIn.TextEditor.RazorLib.CompilerServices;

namespace DevIn.Extensions.DotNet.TestExplorers.Displays.Internals;

public partial class TestExplorerTreeViewDisplay : ComponentBase
{
	[Inject]
	private ITreeViewService TreeViewService { get; set; } = null!;
	[Inject]
	private INotificationService NotificationService { get; set; } = null!;
	[Inject]
	private IDropdownService DropdownService { get; set; } = null!;
	[Inject]
	private BackgroundTaskService BackgroundTaskService { get; set; } = null!;
	[Inject]
	private ICommonComponentRenderers CommonComponentRenderers { get; set; } = null!;
	[Inject]
	private ICompilerServiceRegistry CompilerServiceRegistry { get; set; } = null!;
	[Inject]
	private TextEditorService TextEditorService { get; set; } = null!;
	[Inject]
	private IServiceProvider ServiceProvider { get; set; } = null!;

	[CascadingParameter]
	public TestExplorerRenderBatchValidated RenderBatch { get; set; } = null!;

	[Parameter, EditorRequired]
	public ElementDimensions ElementDimensions { get; set; } = null!;

	private TestExplorerTreeViewKeyboardEventHandler _treeViewKeyboardEventHandler = null!;
	private TestExplorerTreeViewMouseEventHandler _treeViewMouseEventHandler = null!;

	private int OffsetPerDepthInPixels => (int)Math.Ceiling(
		RenderBatch.AppOptionsState.Options.IconSizeInPixels * (2.0 / 3.0));

	protected override void OnInitialized()
	{
		_treeViewKeyboardEventHandler = new TestExplorerTreeViewKeyboardEventHandler(
			CommonComponentRenderers,
			CompilerServiceRegistry,
			TextEditorService,
			NotificationService,
			ServiceProvider,
			TreeViewService,
			BackgroundTaskService);

		_treeViewMouseEventHandler = new TestExplorerTreeViewMouseEventHandler(
			CommonComponentRenderers,
			CompilerServiceRegistry,
			TextEditorService,
			NotificationService,
			ServiceProvider,
			TreeViewService,
			BackgroundTaskService);

		base.OnInitialized();
	}

	private Task OnTreeViewContextMenuFunc(TreeViewCommandArgs treeViewCommandArgs)
	{
		var dropdownRecord = new DropdownRecord(
			TestExplorerContextMenu.ContextMenuEventDropdownKey,
			treeViewCommandArgs.ContextMenuFixedPosition.LeftPositionInPixels,
			treeViewCommandArgs.ContextMenuFixedPosition.TopPositionInPixels,
			typeof(TestExplorerContextMenu),
			new Dictionary<string, object?>
			{
				{
					nameof(TestExplorerContextMenu.TreeViewCommandArgs),
					treeViewCommandArgs
				}
			},
			restoreFocusOnClose: null);

		DropdownService.ReduceRegisterAction(dropdownRecord);
		return Task.CompletedTask;
	}
}