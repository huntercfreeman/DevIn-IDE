using DevIn.Common.RazorLib.ComponentRenderers.Models;
using DevIn.Common.RazorLib.WatchWindows.Models;
using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.CompilerServices.DotNetSolution.Models;
using DevIn.Ide.RazorLib.ComponentRenderers.Models;
using DevIn.Extensions.DotNet.ComponentRenderers.Models;

namespace DevIn.Extensions.DotNet.DotNetSolutions.Models;

public class TreeViewSolution : TreeViewWithType<DotNetSolutionModel>
{
	public TreeViewSolution(
			DotNetSolutionModel dotNetSolutionModel,
			IDotNetComponentRenderers dotNetComponentRenderers,
			IIdeComponentRenderers ideComponentRenderers,
			ICommonComponentRenderers commonComponentRenderers,
			IFileSystemProvider fileSystemProvider,
			IEnvironmentProvider environmentProvider,
			bool isExpandable,
			bool isExpanded)
		: base(dotNetSolutionModel, isExpandable, isExpanded)
	{
		DotNetComponentRenderers = dotNetComponentRenderers;
		IdeComponentRenderers = ideComponentRenderers;
		CommonComponentRenderers = commonComponentRenderers;
		FileSystemProvider = fileSystemProvider;
		EnvironmentProvider = environmentProvider;
	}

	public IDotNetComponentRenderers DotNetComponentRenderers { get; }
	public IIdeComponentRenderers IdeComponentRenderers { get; }
	public ICommonComponentRenderers CommonComponentRenderers { get; }
	public IFileSystemProvider FileSystemProvider { get; }
	public IEnvironmentProvider EnvironmentProvider { get; }

	public override bool Equals(object? obj)
	{
		if (obj is not TreeViewSolution treeViewSolution)
			return false;

		return treeViewSolution.Item.AbsolutePath.Value ==
			   Item.AbsolutePath.Value;
	}

	public override int GetHashCode() => Item.AbsolutePath.Value.GetHashCode();

	public override TreeViewRenderer GetTreeViewRenderer()
	{
		return new TreeViewRenderer(
			IdeComponentRenderers.IdeTreeViews.TreeViewNamespacePathRendererType,
			new Dictionary<string, object?>
			{
				{
					nameof(ITreeViewNamespacePathRendererType.NamespacePath),
					Item.NamespacePath
				},
			});
	}

	public override async Task LoadChildListAsync()
	{
		try
		{
			var previousChildren = new List<TreeViewNoType>(ChildList);

			var newChildList = await TreeViewHelperDotNetSolution.LoadChildrenAsync(this).ConfigureAwait(false);

			ChildList = newChildList;
			LinkChildren(previousChildren, ChildList);
		}
		catch (Exception exception)
		{
			ChildList = new List<TreeViewNoType>
			{
				new TreeViewException(exception, false, false, CommonComponentRenderers)
				{
					Parent = this,
					IndexAmongSiblings = 0,
				}
			};
		}

		TreeViewChangedKey = Key<TreeViewChanged>.NewKey();
	}

	public override void RemoveRelatedFilesFromParent(List<TreeViewNoType> siblingsAndSelfTreeViews)
	{
		return;
	}
}