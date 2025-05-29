using DevIn.Common.RazorLib.ComponentRenderers.Models;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.Dialogs.Models;
using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.Notifications.Models;
using DevIn.Extensions.DotNet.CSharpProjects.Models;
using DevIn.Extensions.DotNet.BackgroundTasks.Models;

namespace DevIn.Extensions.DotNet.Websites;

public class WebsiteDotNetCliHelper
{
	public static async Task StartNewCSharpProjectCommand(
		CSharpProjectFormViewModelImmutable immutableView,
		IEnvironmentProvider environmentProvider,
		IFileSystemProvider fileSystemProvider,
		DotNetBackgroundTaskApi compilerServicesBackgroundTaskApi,
		INotificationService notificationService,
		IDialogService dialogService,
		IDialog dialogRecord,
		ICommonComponentRenderers commonComponentRenderers)
	{
		return;
	}
}
