using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Reactives.Models;

namespace DevIn.Common.RazorLib.Notifications.Displays;

public partial class CommonProgressNotificationDisplay : ComponentBase
{
	[Parameter, EditorRequired]
	public ProgressBarModel ProgressBarModel { get; set; } = null!;
}