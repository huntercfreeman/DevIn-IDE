using Microsoft.AspNetCore.Components.Web;
using DevIn.Common.RazorLib.Keymaps.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib.Options.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models.Internals;

namespace DevIn.TextEditor.RazorLib.Keymaps.Models;

/// <summary>
/// Are you not just writing the name of the keymap?
/// (or some unique identifier).
/// into local storage?
/// </summary>
public interface ITextEditorKeymap
{
	public string DisplayName { get; }

	public Key<KeymapLayer> GetLayer(bool hasSelection);

    public string GetCursorCssClassString();

    public string GetCursorCssStyleString(
        TextEditorModel textEditorModel,
        TextEditorViewModel textEditorViewModel,
        TextEditorOptions textEditorOptions);
	
	public ValueTask HandleEvent(
    	TextEditorComponentData componentData,
	    Key<TextEditorViewModel> viewModelKey,
	    KeyboardEventArgs keyboardEventArgs);
}