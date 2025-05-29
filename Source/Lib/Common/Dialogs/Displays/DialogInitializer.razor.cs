using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Dialogs.Models;
using DevIn.Common.RazorLib.Contexts.Displays;
using DevIn.Common.RazorLib.Dynamics.Models;

namespace DevIn.Common.RazorLib.Dialogs.Displays;

public partial class DialogInitializer : ComponentBase, IDisposable
{
	[Inject]
	private IDialogService DialogService { get; set; } = null!;
	
    private ContextBoundary? _dialogContextBoundary;
    
    protected override void OnInitialized()
    {
    	DialogService.DialogStateChanged += OnDialogStateChanged;
    	base.OnInitialized();
    }
    
    private Task HandleOnFocusIn(IDialog dialog)
    {
    	var localDialogContextBoundary = _dialogContextBoundary;
    	
    	if (localDialogContextBoundary is not null)
	    	localDialogContextBoundary.HandleOnFocusIn();
    
    	return Task.CompletedTask;
    }
    
    private Task HandleOnFocusOut(IDialog dialog)
    {
    	return Task.CompletedTask;
    }
    
    private async void OnDialogStateChanged()
    {
    	await InvokeAsync(StateHasChanged);
    }
    
    public void Dispose()
    {
    	DialogService.DialogStateChanged -= OnDialogStateChanged;
    }
}