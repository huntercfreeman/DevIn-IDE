using DevIn.Common.RazorLib.Keymaps.Models;
using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.Common.RazorLib.Contexts.Models;

public record struct ContextRecord(
    Key<ContextRecord> ContextKey,
    string DisplayNameFriendly,
    string ContextNameInternal,
    IKeymap Keymap)
{
    public string ContextElementId => $"di_ide_context-{ContextKey.Guid}";
}
