using Microsoft.AspNetCore.Components;

namespace DevIn.Common.RazorLib.Notifications.Displays;

public partial class CommonErrorNotificationDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public string Message { get; set; } = null!;
}