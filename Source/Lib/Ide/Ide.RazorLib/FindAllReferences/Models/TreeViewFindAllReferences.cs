/*
// FindAllReferences
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Ide.RazorLib.FindAllReferences.Displays;

namespace DevIn.Ide.RazorLib.FindAllReferences.Models;

public class TreeViewFindAllReferences : TreeViewWithType<ResourceUri>
{
	public TreeViewFindAllReferences(
			ResourceUri resourceUri,
			bool isExpandable,
			bool isExpanded)
		: base(resourceUri, isExpandable, isExpanded)
	{
	}

	public override bool Equals(object? obj)
	{
		if (obj is not TreeViewFindAllReferences otherTreeView)
			return false;

		return otherTreeView.Item == Item;
	}

	public override int GetHashCode() => Item.GetHashCode();

	public override TreeViewRenderer GetTreeViewRenderer()
	{
		return new TreeViewRenderer(
			typeof(TreeViewFindAllReferencesDisplay),
			new Dictionary<string, object?>
			{
				{
					nameof(TreeViewFindAllReferencesDisplay.TreeViewFindAllReferences),
					this
				},
			});
	}

	public override Task LoadChildListAsync()
	{
		return Task.CompletedTask;
	}

	public override void RemoveRelatedFilesFromParent(List<TreeViewNoType> siblingsAndSelfTreeViews)
	{
		return;
	}
}

*/