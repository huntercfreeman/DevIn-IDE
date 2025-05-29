using DevIn.CompilerServices.DotNetSolution.Models.Project;

namespace DevIn.Extensions.DotNet.ComponentRenderers.Models;

public interface ITreeViewCSharpProjectToProjectReferenceRendererType
{
	public CSharpProjectToProjectReference CSharpProjectToProjectReference { get; set; }
}