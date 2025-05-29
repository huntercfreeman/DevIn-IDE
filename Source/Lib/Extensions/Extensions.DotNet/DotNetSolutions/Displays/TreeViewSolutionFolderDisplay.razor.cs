using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.CompilerServices.DotNetSolution.Models.Project;
using DevIn.Extensions.DotNet.ComponentRenderers.Models;

namespace DevIn.Extensions.DotNet.DotNetSolutions.Displays;

public partial class TreeViewSolutionFolderDisplay : ComponentBase, ITreeViewSolutionFolderRendererType
{
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;
    
	[Parameter, EditorRequired]
	public SolutionFolder DotNetSolutionFolder { get; set; } = null!;
}