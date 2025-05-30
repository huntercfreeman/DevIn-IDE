using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.Common.RazorLib.RenderStates.Models;
using DevIn.TextEditor.RazorLib.Keymaps.Models;
using DevIn.TextEditor.RazorLib.JavaScriptObjects.Models;

namespace DevIn.TextEditor.RazorLib.Options.Models;

public record TextEditorOptions(
    CommonOptions CommonOptions,
    bool ShowWhitespace,
    bool ShowNewlines,
    int? TextEditorHeightInPixels,
    double CursorWidthInPixels,
    bool UseMonospaceOptimizations,
    CharAndLineMeasurements CharAndLineMeasurements)
{
    public Key<RenderState> RenderStateKey { get; init; } = Key<RenderState>.NewKey();
    
    /// <summary>
    /// Hacky setter on this property in particular because it can be overridden.
    /// And when overridden it causes an object allocation, and this happens frequently enough to be cause for concern.
    /// </summary>
    public ITextEditorKeymap Keymap { get; set; }
}
