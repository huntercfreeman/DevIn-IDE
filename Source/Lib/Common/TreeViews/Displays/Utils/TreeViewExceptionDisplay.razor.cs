using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.ComponentRenderers.Models;
using DevIn.Common.RazorLib.WatchWindows.Models;
using DevIn.Common.RazorLib.Options.Models;


namespace DevIn.Common.RazorLib.TreeViews.Displays.Utils;

public partial class TreeViewExceptionDisplay : ComponentBase, ITreeViewExceptionRendererType
{
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;
    
    [Parameter, EditorRequired]
    public TreeViewException TreeViewException { get; set; } = null!;
}