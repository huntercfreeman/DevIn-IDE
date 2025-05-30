using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Dimensions.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;

namespace DevIn.Ide.RazorLib.CodeSearches.Models;

public record struct CodeSearchState(
    string Query,
    string? StartingAbsolutePathForSearch,
    CodeSearchFilterKind CodeSearchFilterKind,
    IReadOnlyList<string> ResultList,
    string PreviewFilePath,
    Key<TextEditorViewModel> PreviewViewModelKey)
{
    public static readonly Key<TreeViewContainer> TreeViewCodeSearchContainerKey = Key<TreeViewContainer>.NewKey();
    
	public CodeSearchState() : this(
        string.Empty,
        null,
        CodeSearchFilterKind.None,
        Array.Empty<string>(),
        string.Empty,
        Key<TextEditorViewModel>.Empty)
    {
		// topContentHeight
        {
			TopContentElementDimensions.HeightDimensionAttribute.DimensionUnitList.AddRange(new[]
			{
				new DimensionUnit(
					40,
					DimensionUnitKind.Percentage),
				new DimensionUnit(
					0,
					DimensionUnitKind.Pixels,
					DimensionOperatorKind.Subtract,
					DimensionUnitFacts.Purposes.OFFSET),
			});
        }

        // bottomContentHeight
        {
            BottomContentElementDimensions.HeightDimensionAttribute.DimensionUnitList.AddRange(new[]
			{
				new DimensionUnit(
					60,
					DimensionUnitKind.Percentage),
				new DimensionUnit(
					0,
					DimensionUnitKind.Pixels,
					DimensionOperatorKind.Subtract,
					DimensionUnitFacts.Purposes.OFFSET),
			});
        }
    }

	public ElementDimensions TopContentElementDimensions = new();
	public ElementDimensions BottomContentElementDimensions = new();
}
