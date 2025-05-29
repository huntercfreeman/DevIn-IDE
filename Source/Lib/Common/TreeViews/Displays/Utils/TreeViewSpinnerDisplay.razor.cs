using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.TreeViews.Models.Utils;
using DevIn.Common.RazorLib.Options.Models;

namespace DevIn.Common.RazorLib.TreeViews.Displays.Utils;

public partial class TreeViewSpinnerDisplay : ComponentBase
{
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;
    
	[Parameter, EditorRequired]
	public TreeViewSpinner TreeViewSpinner { get; set; } = null!;
}