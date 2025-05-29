using DevIn.Common.RazorLib.Options.Models;
using DevIn.Common.RazorLib.TreeViews.Models;

namespace DevIn.Extensions.DotNet.TestExplorers.Models;

public class TestExplorerRenderBatch : ITestExplorerRenderBatch
{
	public TestExplorerRenderBatch(
		TestExplorerState testExplorerState,
		AppOptionsState appOptionsState,
		TreeViewContainer? treeViewContainer)
	{
		TestExplorerState = testExplorerState;
		AppOptionsState = appOptionsState;
		TreeViewContainer = treeViewContainer;
	}

	public TestExplorerState TestExplorerState { get; }
	public AppOptionsState AppOptionsState { get; }
	public TreeViewContainer? TreeViewContainer { get; }
}
