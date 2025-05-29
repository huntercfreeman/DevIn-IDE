using DevIn.CompilerServices.DotNetSolution.Models.Project;

namespace DevIn.Extensions.DotNet.ComponentRenderers.Models;

public interface ITreeViewSolutionFolderRendererType
{
	public SolutionFolder DotNetSolutionFolder { get; set; }
}