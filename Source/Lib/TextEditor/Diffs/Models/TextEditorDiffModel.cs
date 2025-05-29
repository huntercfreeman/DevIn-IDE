using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.RenderStates.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;

namespace DevIn.TextEditor.RazorLib.Diffs.Models;

public record TextEditorDiffModel(
    Key<TextEditorDiffModel> DiffKey,
    Key<TextEditorViewModel> InViewModelKey,
    Key<TextEditorViewModel> OutViewModelKey)
{
    public Key<RenderState> RenderStateKey { get; init; } = Key<RenderState>.NewKey();
}
