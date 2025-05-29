using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.CompilerServices.DotNetSolution.Models.Project;
using DevIn.Extensions.DotNet.ComponentRenderers.Models;

namespace DevIn.Extensions.DotNet.CSharpProjects.Displays;

public partial class TreeViewCSharpProjectToProjectReferenceDisplay : ComponentBase, ITreeViewCSharpProjectToProjectReferenceRendererType
{
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;
    
	[Parameter, EditorRequired]
	public CSharpProjectToProjectReference CSharpProjectToProjectReference { get; set; } = null!;
}