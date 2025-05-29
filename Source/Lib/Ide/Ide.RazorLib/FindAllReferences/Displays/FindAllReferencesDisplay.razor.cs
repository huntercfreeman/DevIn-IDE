/*
// FindAllReferences
using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Panels.Models;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.Dropdowns.Models;
using DevIn.TextEditor.RazorLib;
using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.TextEditor.RazorLib.TextEditors.Models;
using DevIn.TextEditor.RazorLib.Installations.Models;
using DevIn.Extensions.CompilerServices;
using DevIn.Ide.RazorLib.FindAllReferences.Models;

namespace DevIn.Ide.RazorLib.FindAllReferences.Displays;

public partial class FindAllReferencesDisplay : ComponentBase, IDisposable
{
	[Inject]
	private IFindAllReferencesService FindAllReferencesService { get; set; } = null!;
	[Inject]
	private ICompilerServiceRegistry CompilerServiceRegistry { get; set; } = null!;
	[Inject]
	private IAppOptionsService AppOptionsService { get; set; } = null!;
	[Inject]
	private ITextEditorService TextEditorService { get; set; } = null!;
	[Inject]
	private DevInTextEditorConfig TextEditorConfig { get; set; } = null!;
	[Inject]
	private IServiceProvider ServiceProvider { get; set; } = null!;
	[Inject]
	private ITreeViewService TreeViewService { get; set; } = null!;
	[Inject]
	private IBackgroundTaskService BackgroundTaskService { get; set; } = null!;
	[Inject]
	private IDropdownService DropdownService { get; set; } = null!;

	public static readonly Key<Panel> FindAllReferencesPanelKey = Key<Panel>.NewKey();
    public static readonly Key<IDynamicViewModel> FindAllReferencesDynamicViewModelKey = Key<IDynamicViewModel>.NewKey();
    
    private IExtendedCompilerService _cSharpCompilerService = null!;
    
    private FindAllReferencesTreeViewKeyboardEventHandler _treeViewKeyboardEventHandler = null!;
	private FindAllReferencesTreeViewMouseEventHandler _treeViewMouseEventHandler = null!;
	*/

	// FindAllReferences
	// private int OffsetPerDepthInPixels => (int)Math.Ceiling(
	// 	AppOptionsService.GetAppOptionsState().Options.IconSizeInPixels * (2.0 / 3.0));
    
    /*
    // FindAllReferences
    protected override void OnInitialized()
    {
    	FindAllReferencesService.FindAllReferencesStateChanged += OnFindAllReferencesStateChanged;
    	
    	_cSharpCompilerService = (IExtendedCompilerService)CompilerServiceRegistry.GetCompilerService(ExtensionNoPeriodFacts.C_SHARP_CLASS);
    	
    	_treeViewKeyboardEventHandler = new FindAllReferencesTreeViewKeyboardEventHandler(
			TextEditorService,
			TextEditorConfig,
			ServiceProvider,
			TreeViewService,
			BackgroundTaskService);

		_treeViewMouseEventHandler = new FindAllReferencesTreeViewMouseEventHandler(
			TextEditorService,
			TextEditorConfig,
			ServiceProvider,
			TreeViewService,
			BackgroundTaskService);
    	
    	base.OnInitialized();
    }
    
    private async void OnFindAllReferencesStateChanged()
    {
    	await InvokeAsync(StateHasChanged);
    }
    
    private Task OnTreeViewContextMenuFunc(TreeViewCommandArgs treeViewCommandArgs)
	{
		var dropdownRecord = new DropdownRecord(
			FindAllReferencesContextMenu.ContextMenuEventDropdownKey,
			treeViewCommandArgs.ContextMenuFixedPosition.LeftPositionInPixels,
			treeViewCommandArgs.ContextMenuFixedPosition.TopPositionInPixels,
			typeof(FindAllReferencesContextMenu),
			new Dictionary<string, object?>
			{
				{
					nameof(FindAllReferencesContextMenu.TreeViewCommandArgs),
					treeViewCommandArgs
				}
			},
			restoreFocusOnClose: null);

		DropdownService.ReduceRegisterAction(dropdownRecord);
		return Task.CompletedTask;
	}
    
    public void Dispose()
    {
    	FindAllReferencesService.FindAllReferencesStateChanged -= OnFindAllReferencesStateChanged;
    }
}
*/
