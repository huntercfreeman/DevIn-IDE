using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using DevIn.Common.RazorLib.Installations.Models;
using DevIn.Ide.RazorLib.JsRuntimes.Models;
using DevIn.Ide.RazorLib.BackgroundTasks.Models;

namespace DevIn.Ide.RazorLib.Installations.Displays;

/// <remarks>
/// This class is an exception to the naming convention, "don't use the word 'DevIn' in class names".
/// 
/// Reason for this exception: when one first starts interacting with this project,
/// 	this type might be one of the first types they interact with. So, the redundancy of namespace
/// 	and type containing 'DevIn' feels reasonable here.
/// </remarks>
public partial class DevInIdeInitializer : ComponentBase
{
    [Inject]
    private IJSRuntime JsRuntime { get; set; } = null!;
    [Inject]
    private DevInHostingInformation DevInHostingInformation { get; set; } = null!;
    [Inject]
    private IdeBackgroundTaskApi IdeBackgroundTaskApi { get; set; } = null!;

	protected override void OnInitialized()
	{
        IdeBackgroundTaskApi.Enqueue(new IdeBackgroundTaskApiWorkArgs
        {
        	WorkKind = IdeBackgroundTaskApiWorkKind.DevInIdeInitializerOnInit,
        });
        base.OnInitialized();
	}
	
	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (firstRender)
		{
			if (DevInHostingInformation.DevInHostingKind == DevInHostingKind.Photino)
			{
				await JsRuntime.GetDevInIdeApi()
					.PreventDefaultBrowserKeybindings();
			}
		}
		
		await base.OnAfterRenderAsync(firstRender);
	}
}