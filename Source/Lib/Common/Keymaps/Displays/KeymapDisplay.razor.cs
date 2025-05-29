using DevIn.Common.RazorLib.Keymaps.Models;
using Microsoft.AspNetCore.Components;

namespace DevIn.Common.RazorLib.Keymaps.Displays;

public partial class KeymapDisplay : ComponentBase
{
    [Inject]
    private IKeymapService KeymapService { get; set; } = null!;

    [Parameter, EditorRequired]
    public IKeymap Keymap { get; set; } = null!;
}