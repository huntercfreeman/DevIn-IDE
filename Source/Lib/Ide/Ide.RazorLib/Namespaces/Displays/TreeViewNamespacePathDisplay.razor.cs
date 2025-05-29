using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Namespaces.Models;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.Ide.RazorLib.ComponentRenderers.Models;

namespace DevIn.Ide.RazorLib.Namespaces.Displays;

public partial class TreeViewNamespacePathDisplay : ComponentBase, ITreeViewNamespacePathRendererType
{
	[Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;

    [CascadingParameter(Name="DevInCommonIconWidthOverride")]
    public int? DevInCommonIconWidthOverride { get; set; }
    [CascadingParameter(Name="DevInCommonIconHeightOverride")]
    public int? DevInCommonIconHeightOverride { get; set; }

	[Parameter, EditorRequired]
    public NamespacePath NamespacePath { get; set; }
    [Parameter]
    public string CssStyleString { get; set; } = string.Empty;
    
    public int WidthInPixels => DevInCommonIconWidthOverride ??
        AppOptionsService.GetAppOptionsState().Options.IconSizeInPixels;

    public int HeightInPixels => DevInCommonIconHeightOverride ??
        AppOptionsService.GetAppOptionsState().Options.IconSizeInPixels;
}