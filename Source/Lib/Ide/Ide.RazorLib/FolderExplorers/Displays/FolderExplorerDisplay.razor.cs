using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.ComponentRenderers.Models;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.Common.RazorLib.Dropdowns.Models;
using DevIn.Common.RazorLib.Notifications.Models;
using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.TextEditor.RazorLib;
using DevIn.Ide.RazorLib.FolderExplorers.Models;
using DevIn.Ide.RazorLib.Menus.Models;
using DevIn.Ide.RazorLib.BackgroundTasks.Models;

namespace DevIn.Ide.RazorLib.FolderExplorers.Displays;

public partial class FolderExplorerDisplay : ComponentBase, IDisposable
{
    [Inject]
    private IFolderExplorerService FolderExplorerService { get; set; } = null!;
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;
    [Inject]
    private INotificationService NotificationService { get; set; } = null!;
    [Inject]
    private IDropdownService DropdownService { get; set; } = null!;
    [Inject]
    private ITreeViewService TreeViewService { get; set; } = null!;
    [Inject]
    private TextEditorService TextEditorService { get; set; } = null!;
    [Inject]
    private ICommonComponentRenderers CommonComponentRenderers { get; set; } = null!;
    [Inject]
    private IMenuOptionsFactory MenuOptionsFactory { get; set; } = null!;
    [Inject]
    private IdeBackgroundTaskApi IdeBackgroundTaskApi { get; set; } = null!;
	[Inject]
    private BackgroundTaskService BackgroundTaskService { get; set; } = null!;
	[Inject]
    private IEnvironmentProvider EnvironmentProvider { get; set; } = null!;

    private FolderExplorerTreeViewMouseEventHandler _treeViewMouseEventHandler = null!;
    private FolderExplorerTreeViewKeyboardEventHandler _treeViewKeyboardEventHandler = null!;

    private int OffsetPerDepthInPixels => (int)Math.Ceiling(
        AppOptionsService.GetAppOptionsState().Options.IconSizeInPixels * (2.0 / 3.0));

    protected override void OnInitialized()
    {
        FolderExplorerService.FolderExplorerStateChanged += OnFolderExplorerStateChanged;
        AppOptionsService.AppOptionsStateChanged += OnAppOptionsStateChanged;

        _treeViewMouseEventHandler = new FolderExplorerTreeViewMouseEventHandler(
            IdeBackgroundTaskApi,
            TextEditorService,
            TreeViewService,
			BackgroundTaskService);

        _treeViewKeyboardEventHandler = new FolderExplorerTreeViewKeyboardEventHandler(
            IdeBackgroundTaskApi,
            TextEditorService,
            MenuOptionsFactory,
            CommonComponentRenderers,
            TreeViewService,
			BackgroundTaskService,
            EnvironmentProvider,
            NotificationService);

        base.OnInitialized();
    }

    private Task OnTreeViewContextMenuFunc(TreeViewCommandArgs treeViewCommandArgs)
    {
		var dropdownRecord = new DropdownRecord(
			FolderExplorerContextMenu.ContextMenuEventDropdownKey,
			treeViewCommandArgs.ContextMenuFixedPosition.LeftPositionInPixels,
			treeViewCommandArgs.ContextMenuFixedPosition.TopPositionInPixels,
			typeof(FolderExplorerContextMenu),
			new Dictionary<string, object?>
			{
				{
					nameof(FolderExplorerContextMenu.TreeViewCommandArgs),
					treeViewCommandArgs
				}
			},
			restoreFocusOnClose: null);

        DropdownService.ReduceRegisterAction(dropdownRecord);
		return Task.CompletedTask;
	}
	
	private async void OnFolderExplorerStateChanged() 
	{
		await InvokeAsync(StateHasChanged);
	}
	
	private async void OnAppOptionsStateChanged()
	{
		await InvokeAsync(StateHasChanged);
	}

    public void Dispose()
    {
        FolderExplorerService.FolderExplorerStateChanged -= OnFolderExplorerStateChanged;
        AppOptionsService.AppOptionsStateChanged -= OnAppOptionsStateChanged;
    }
}