using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.TextEditor.RazorLib.Edits.Models;

public record struct DirtyResourceUriState(List<ResourceUri> DirtyResourceUriList)
{
    public DirtyResourceUriState() : this(new())
    {
    }
}
