using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Options.Models;

namespace DevIn.Ide.RazorLib.Notifications.Displays;

public partial class NotificationsDisplay : ComponentBase
{
	[Inject]
	private IAppOptionsService AppOptionsService { get; set; } = null!;
}