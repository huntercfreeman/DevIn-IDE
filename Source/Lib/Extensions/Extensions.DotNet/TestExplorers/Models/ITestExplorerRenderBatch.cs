using DevIn.Common.RazorLib.Options.Models;
using DevIn.Common.RazorLib.TreeViews.Models;

namespace DevIn.Extensions.DotNet.TestExplorers.Models;

public interface ITestExplorerRenderBatch
{
	public TestExplorerState TestExplorerState { get; }
	public AppOptionsState AppOptionsState { get; }
	public TreeViewContainer? TreeViewContainer { get; }
}
