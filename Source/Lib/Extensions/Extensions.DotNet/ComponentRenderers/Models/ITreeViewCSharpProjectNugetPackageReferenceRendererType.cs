using DevIn.Extensions.DotNet.Nugets.Models;

namespace DevIn.Extensions.DotNet.ComponentRenderers.Models;

public interface ITreeViewCSharpProjectNugetPackageReferenceRendererType
{
	public CSharpProjectNugetPackageReference CSharpProjectNugetPackageReference { get; set; }
}