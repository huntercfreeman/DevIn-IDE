using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.Dropdowns.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.TextEditor.RazorLib;
using DevIn.TextEditor.RazorLib.Installations.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models.Internals;
using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Ide.RazorLib.CodeSearches.Models;

namespace DevIn.Ide.RazorLib.CodeSearches.Displays;

public partial class CodeSearchDisplay : ComponentBase, IDisposable
{
	[Inject]
	private ICodeSearchService CodeSearchService { get; set; } = null!;
    [Inject]
	private IAppOptionsService AppOptionsService { get; set; } = null!;
	[Inject]
	private DevInTextEditorConfig TextEditorConfig { get; set; } = null!;
	[Inject]
	private IDropdownService DropdownService { get; set; } = null!;
	[Inject]
	private TextEditorService TextEditorService { get; set; } = null!;
	[Inject]
	private ITreeViewService TreeViewService { get; set; } = null!;
    [Inject]
    private BackgroundTaskService BackgroundTaskService { get; set; } = null!;
    [Inject]
    private IEnvironmentProvider EnvironmentProvider { get; set; } = null!;
    [Inject]
	private IServiceProvider ServiceProvider { get; set; } = null!;
	
	private CodeSearchTreeViewKeyboardEventHandler _treeViewKeymap = null!;
	private CodeSearchTreeViewMouseEventHandler _treeViewMouseEventHandler = null!;
    
    private int OffsetPerDepthInPixels => (int)Math.Ceiling(
		AppOptionsService.GetAppOptionsState().Options.IconSizeInPixels * (2.0 / 3.0));

	private readonly ViewModelDisplayOptions _textEditorViewModelDisplayOptions = new()
	{
		HeaderComponentType = null,
	};

    private string InputValue
	{
		get => CodeSearchService.GetCodeSearchState().Query;
		set
		{
			if (value is null)
				value = string.Empty;

			CodeSearchService.With(inState => inState with
			{
				Query = value,
			});

			CodeSearchService.HandleSearchEffect();
		}
	}
	
	protected override void OnInitialized()
	{
		CodeSearchService.CodeSearchStateChanged += OnCodeSearchStateChanged;
		TreeViewService.TreeViewStateChanged += OnTreeViewStateChanged;
	
		_treeViewKeymap = new CodeSearchTreeViewKeyboardEventHandler(
			TextEditorService,
			TextEditorConfig,
			ServiceProvider,
			TreeViewService,
			BackgroundTaskService);

		_treeViewMouseEventHandler = new CodeSearchTreeViewMouseEventHandler(
			TextEditorService,
			TextEditorConfig,
			ServiceProvider,
			TreeViewService,
			BackgroundTaskService);

		base.OnInitialized();
	}
	
	protected override void OnAfterRender(bool firstRender)
	{
		CodeSearchService._updateContentThrottle.Run(_ => CodeSearchService.UpdateContent(ResourceUri.Empty));
		base.OnAfterRender(firstRender);
	}
	
	private Task OnTreeViewContextMenuFunc(TreeViewCommandArgs treeViewCommandArgs)
	{
		var dropdownRecord = new DropdownRecord(
			CodeSearchContextMenu.ContextMenuEventDropdownKey,
			treeViewCommandArgs.ContextMenuFixedPosition.LeftPositionInPixels,
			treeViewCommandArgs.ContextMenuFixedPosition.TopPositionInPixels,
			typeof(CodeSearchContextMenu),
			new Dictionary<string, object?>
			{
				{
					nameof(CodeSearchContextMenu.TreeViewCommandArgs),
					treeViewCommandArgs
				}
			},
			null);

		DropdownService.ReduceRegisterAction(dropdownRecord);
		return Task.CompletedTask;
	}

	private string GetIsActiveCssClass(CodeSearchFilterKind codeSearchFilterKind)
	{
		return CodeSearchService.GetCodeSearchState().CodeSearchFilterKind == codeSearchFilterKind
			? "di_active"
			: string.Empty;
	}

	private async Task HandleResizableRowReRenderAsync()
	{
		await InvokeAsync(StateHasChanged);
	}
    
    public async void OnTreeViewStateChanged()
    {
    	await InvokeAsync(StateHasChanged);
    }
    
    public async void OnCodeSearchStateChanged()
    {
    	await InvokeAsync(StateHasChanged);
    }
    
    public void Dispose()
    {
    	CodeSearchService.CodeSearchStateChanged -= OnCodeSearchStateChanged;
    	TreeViewService.TreeViewStateChanged -= OnTreeViewStateChanged;
    }
}