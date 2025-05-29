using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Contexts.Models;

namespace DevIn.Common.RazorLib.Contexts.Displays;

public partial class ContextInitializerDisplay : ComponentBase, IDisposable
{
    [Inject]
    private IContextService ContextService { get; set; } = null!;
    
    protected override void OnInitialized()
    {
    	ContextService.ContextStateChanged += OnContextStateChanged;
    	base.OnInitialized();
    }
    
    private async void OnContextStateChanged()
    {
    	await InvokeAsync(StateHasChanged);
    }
    
    public void Dispose()
    {
    	ContextService.ContextStateChanged -= OnContextStateChanged;
    }
}
