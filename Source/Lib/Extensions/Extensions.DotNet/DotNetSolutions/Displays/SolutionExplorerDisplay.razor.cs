using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.ComponentRenderers.Models;
using DevIn.Common.RazorLib.Dropdowns.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.Notifications.Models;
using DevIn.Common.RazorLib.Dialogs.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.TextEditor.RazorLib;
using DevIn.Ide.RazorLib.Menus.Models;
using DevIn.Ide.RazorLib.BackgroundTasks.Models;
using DevIn.Extensions.DotNet.DotNetSolutions.Models;
using DevIn.Extensions.DotNet.DotNetSolutions.Displays.Internals;
using DevIn.Extensions.DotNet.BackgroundTasks.Models;

namespace DevIn.Extensions.DotNet.DotNetSolutions.Displays;

public partial class SolutionExplorerDisplay : ComponentBase, IDisposable
{
	[Inject]
	private ITreeViewService TreeViewService { get; set; } = null!;
	[Inject]
	private IDialogService DialogService { get; set; } = null!;
	[Inject]
	private INotificationService NotificationService { get; set; } = null!;
	[Inject]
	private IDropdownService DropdownService { get; set; } = null!;
	[Inject]
	private IAppOptionsService AppOptionsService { get; set; } = null!;
	[Inject]
	private ICommonComponentRenderers CommonComponentRenderers { get; set; } = null!;
	[Inject]
	private IMenuOptionsFactory MenuOptionsFactory { get; set; } = null!;
	[Inject]
	private IdeBackgroundTaskApi IdeBackgroundTaskApi { get; set; } = null!;
	[Inject]
	private DotNetBackgroundTaskApi DotNetBackgroundTaskApi { get; set; } = null!;
	[Inject]
	private BackgroundTaskService BackgroundTaskService { get; set; } = null!;
	[Inject]
	private IEnvironmentProvider EnvironmentProvider { get; set; } = null!;
	[Inject]
	private TextEditorService TextEditorService { get; set; } = null!;

	private SolutionExplorerTreeViewKeyboardEventHandler _solutionExplorerTreeViewKeymap = null!;
	private SolutionExplorerTreeViewMouseEventHandler _solutionExplorerTreeViewMouseEventHandler = null!;

	private int OffsetPerDepthInPixels => (int)Math.Ceiling(
		AppOptionsService.GetAppOptionsState().Options.IconSizeInPixels * (2.0 / 3.0));

	protected override void OnInitialized()
	{
		DotNetBackgroundTaskApi.DotNetSolutionService.DotNetSolutionStateChanged += OnDotNetSolutionStateChanged;
	
		_solutionExplorerTreeViewKeymap = new SolutionExplorerTreeViewKeyboardEventHandler(
			IdeBackgroundTaskApi,
			MenuOptionsFactory,
			CommonComponentRenderers,
			TextEditorService,
			TreeViewService,
			NotificationService,
			BackgroundTaskService,
			EnvironmentProvider);

		_solutionExplorerTreeViewMouseEventHandler = new SolutionExplorerTreeViewMouseEventHandler(
			IdeBackgroundTaskApi,
			TextEditorService,
			TreeViewService,
			BackgroundTaskService);

		base.OnInitialized();
	}

	private Task OnTreeViewContextMenuFunc(TreeViewCommandArgs treeViewCommandArgs)
	{
		var dropdownRecord = new DropdownRecord(
			SolutionExplorerContextMenu.ContextMenuEventDropdownKey,
			treeViewCommandArgs.ContextMenuFixedPosition.LeftPositionInPixels,
			treeViewCommandArgs.ContextMenuFixedPosition.TopPositionInPixels,
			typeof(SolutionExplorerContextMenu),
			new Dictionary<string, object?>
			{
				{
					nameof(SolutionExplorerContextMenu.TreeViewCommandArgs),
					treeViewCommandArgs
				}
			},
			null);

		DropdownService.ReduceRegisterAction(dropdownRecord);
		return Task.CompletedTask;
	}

	private void OpenNewDotNetSolutionDialog()
	{
		var dialogRecord = new DialogViewModel(
			Key<IDynamicViewModel>.NewKey(),
			"New .NET Solution",
			typeof(DotNetSolutionFormDisplay),
			null,
			null,
			true,
			null);

		DialogService.ReduceRegisterAction(dialogRecord);
	}
	
	public async void OnDotNetSolutionStateChanged()
	{
		await InvokeAsync(StateHasChanged);
	}
	
	public void Dispose()
	{
		DotNetBackgroundTaskApi.DotNetSolutionService.DotNetSolutionStateChanged -= OnDotNetSolutionStateChanged;
	}
}