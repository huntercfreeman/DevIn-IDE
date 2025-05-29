using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Ide.RazorLib.Terminals.Models;

namespace DevIn.Ide.RazorLib.Terminals.Displays;

public partial class TerminalGroupDisplay : ComponentBase, IDisposable
{
    [Inject]
    private ITerminalGroupService TerminalGroupService { get; set; } = null!;
    [Inject]
    private ITerminalService TerminalService { get; set; } = null!;
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;

	private Key<IDynamicViewModel> _addIntegratedTerminalDialogKey = Key<IDynamicViewModel>.NewKey();

	protected override void OnInitialized()
	{
		TerminalGroupService.TerminalGroupStateChanged += OnTerminalGroupStateChanged;
    	TerminalService.TerminalStateChanged += OnTerminalStateChanged;
    	
		base.OnInitialized();
	}

    private void DispatchSetActiveTerminalAction(Key<ITerminal> terminalKey)
    {
        TerminalGroupService.SetActiveTerminal(terminalKey);
    }
    
    private void ClearTerminalOnClick(Key<ITerminal> terminalKey)
    {
    	TerminalService.GetTerminalState().TerminalMap[terminalKey]?.ClearFireAndForget();
    }
    
    private async void OnTerminalGroupStateChanged()
    {
    	await InvokeAsync(StateHasChanged);
    }
    
    private async void OnTerminalStateChanged()
    {
    	await InvokeAsync(StateHasChanged);
    }
    
    public void Dispose()
    {
    	TerminalGroupService.TerminalGroupStateChanged -= OnTerminalGroupStateChanged;
    	TerminalService.TerminalStateChanged -= OnTerminalStateChanged;
    }
}