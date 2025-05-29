using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;

namespace DevIn.Extensions.DotNet.CompilerServices.Models;

public record struct CompilerServiceEditorState(Key<TextEditorViewModel> TextEditorViewModelKey)
{
    public CompilerServiceEditorState() : this(Key<TextEditorViewModel>.Empty)
    {
        
    }
}
