using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.Extensions.DotNet.Nugets.Models;
using DevIn.Extensions.DotNet.ComponentRenderers.Models;

namespace DevIn.Extensions.DotNet.CSharpProjects.Displays;

public partial class TreeViewCSharpProjectNugetPackageReferenceDisplay : ComponentBase, ITreeViewCSharpProjectNugetPackageReferenceRendererType
{
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;
    
	[Parameter, EditorRequired]
	public CSharpProjectNugetPackageReference CSharpProjectNugetPackageReference { get; set; } = null!;
}