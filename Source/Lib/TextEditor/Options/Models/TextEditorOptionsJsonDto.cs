using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.Common.RazorLib.RenderStates.Models;

namespace DevIn.TextEditor.RazorLib.Options.Models;

/// <summary>
/// This type needs to exist so the <see cref="TextEditorOptions"/> properties can be nullable, as in they were not
/// already in local storage. Whereas throughout the app they should never be null.
/// </summary>
public record TextEditorOptionsJsonDto(
    CommonOptionsJsonDto? CommonOptionsJsonDto,
    bool? ShowWhitespace,
    bool? ShowNewlines,
    int? TextEditorHeightInPixels,
    double? CursorWidthInPixels,
    //ITextEditorKeymap? Keymap,
    bool? UseMonospaceOptimizations)
{
    public TextEditorOptionsJsonDto()
        : this(null, null, null, null, null, null)
    {
    }
    
    public TextEditorOptionsJsonDto(TextEditorOptions options)
        : this(
              new CommonOptionsJsonDto(options.CommonOptions),
              options.ShowWhitespace,
              options.ShowNewlines,
              options.TextEditorHeightInPixels,
              options.CursorWidthInPixels,
              //options.Keymap,
              options.UseMonospaceOptimizations)
    {
        
    }

    public Key<RenderState> RenderStateKey { get; init; } = Key<RenderState>.NewKey();
}