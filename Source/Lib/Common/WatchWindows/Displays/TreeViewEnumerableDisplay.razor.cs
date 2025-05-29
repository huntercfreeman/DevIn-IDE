using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.WatchWindows.Models;
using DevIn.Common.RazorLib.Options.Models;

namespace DevIn.Common.RazorLib.WatchWindows.Displays;

public partial class TreeViewEnumerableDisplay : ComponentBase
{
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;
    
    [Parameter, EditorRequired]
    public TreeViewEnumerable TreeViewEnumerable { get; set; } = null!;
}