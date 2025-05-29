using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Options.Models;

namespace DevIn.Common.RazorLib.Icons.Models;

public class IconBase : ComponentBase
{
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;

    [CascadingParameter(Name = "DevInCommonIconWidthOverride")]
    public int? DevInCommonIconWidthOverride { get; set; }
    [CascadingParameter(Name = "DevInCommonIconHeightOverride")]
    public int? DevInCommonIconHeightOverride { get; set; }

    [Parameter]
    public string CssStyleString { get; set; } = string.Empty;

    public int WidthInPixels => DevInCommonIconWidthOverride ??
        AppOptionsService.GetAppOptionsState().Options.IconSizeInPixels;

    public int HeightInPixels => DevInCommonIconHeightOverride ??
        AppOptionsService.GetAppOptionsState().Options.IconSizeInPixels;
}