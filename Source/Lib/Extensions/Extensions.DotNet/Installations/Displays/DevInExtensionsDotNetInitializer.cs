using Microsoft.AspNetCore.Components;
using DevIn.Extensions.DotNet.BackgroundTasks.Models;

namespace DevIn.Extensions.DotNet.Installations.Displays;

public partial class DevInExtensionsDotNetInitializer : ComponentBase
{
    [Inject]
	private DotNetBackgroundTaskApi DotNetBackgroundTaskApi { get; set; } = null!;

    protected override void OnInitialized()
	{
		DotNetBackgroundTaskApi.Enqueue(new DotNetBackgroundTaskApiWorkArgs
		{
			WorkKind = DotNetBackgroundTaskApiWorkKind.DevInExtensionsDotNetInitializerOnInit,
		});
		base.OnInitialized();
	}
	
	protected override void OnAfterRender(bool firstRender)
	{
		if (firstRender)
		{
            DotNetBackgroundTaskApi.Enqueue(new DotNetBackgroundTaskApiWorkArgs
            {
            	WorkKind = DotNetBackgroundTaskApiWorkKind.DevInExtensionsDotNetInitializerOnAfterRender
            });
		}
	}
}