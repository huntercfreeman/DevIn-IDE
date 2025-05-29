using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.Ide.RazorLib.Terminals.Models;
using DevIn.Extensions.DotNet.TestExplorers.Models;

namespace DevIn.Extensions.DotNet.TestExplorers.Displays.Internals;

public partial class TreeViewStringFragmentDisplay : ComponentBase, IDisposable
{
	[Inject]
	private ITerminalService TerminalService { get; set; } = null!;
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;

	[Parameter, EditorRequired]
	public TreeViewStringFragment TreeViewStringFragment { get; set; } = null!;

	protected override void OnInitialized()
	{
		TerminalService.TerminalStateChanged += OnTerminalStateChanged;
		base.OnInitialized();
	}

	private string? GetTerminalCommandRequestOutput(ITerminal terminal)
	{
		return TreeViewStringFragment.Item.TerminalCommandParsed?.OutputCache.ToString() ?? null;
	}
	
	private async void OnTerminalStateChanged()
	{
		await InvokeAsync(StateHasChanged);
	}
	
	public void Dispose()
	{
		TerminalService.TerminalStateChanged -= OnTerminalStateChanged;
	}
}