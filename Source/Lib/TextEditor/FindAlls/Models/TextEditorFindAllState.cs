using DevIn.Common.RazorLib.Reactives.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.TextEditor.RazorLib.FindAlls.Models;

public record struct TextEditorFindAllState(
	string SearchQuery,
	string StartingDirectoryPath,
	List<TextEditorTextSpan> SearchResultList,
	ProgressBarModel? ProgressBarModel)
{
	public static readonly Key<TreeViewContainer> TreeViewFindAllContainerKey = Key<TreeViewContainer>.NewKey();

    public TextEditorFindAllState() : this(
    	string.Empty,
    	string.Empty,
    	new(),
    	null)
    {
    }
}