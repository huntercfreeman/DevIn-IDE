using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.TextEditor.RazorLib.FindAlls.Displays;
using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.TextEditor.RazorLib.FindAlls.Models;

public class TreeViewFindAllTextSpan : TreeViewWithType<TextEditorTextSpan>
{
	public TreeViewFindAllTextSpan(
			TextEditorTextSpan textSpan,
			AbsolutePath absolutePath,
			bool isExpandable,
			bool isExpanded)
		: base(textSpan, isExpandable, isExpanded)
	{
		AbsolutePath = absolutePath;
	}
	
	public AbsolutePath AbsolutePath { get; }
	public string? PreviewEarlierNearbyText { get; set; }
	public string? PreviewLaterNearbyText { get; set; }
	
	public override bool Equals(object? obj)
	{
		if (obj is not TreeViewFindAllTextSpan otherTreeView)
			return false;

		return otherTreeView.GetHashCode() == GetHashCode();
	}

	public override int GetHashCode() => Item.ResourceUri.Value.GetHashCode();
	
	public override TreeViewRenderer GetTreeViewRenderer()
	{
		return new TreeViewRenderer(
			typeof(TreeViewFindAllTextSpanDisplay),
			new Dictionary<string, object?>
			{
				{
					nameof(TreeViewFindAllTextSpanDisplay.TreeViewFindAllTextSpan),
					this
				}
			});
	}
	
	public override Task LoadChildListAsync()
	{
		return Task.CompletedTask;
	}
}
