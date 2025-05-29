using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.WatchWindows.Models;
using DevIn.Common.RazorLib.Options.Models;

namespace DevIn.Common.RazorLib.WatchWindows.Displays;

public partial class TreeViewPropertiesDisplay : ComponentBase
{
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;
    
    [Parameter, EditorRequired]
    public TreeViewProperties TreeViewProperties { get; set; } = null!;
}