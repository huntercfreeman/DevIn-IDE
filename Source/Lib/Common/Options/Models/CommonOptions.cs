using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Themes.Models;

namespace DevIn.Common.RazorLib.Options.Models;

public record CommonOptions(
    int FontSizeInPixels,
    int IconSizeInPixels,
    int ResizeHandleWidthInPixels,
    int ResizeHandleHeightInPixels,
    Key<ThemeRecord> ThemeKey,
    string? FontFamily,
    bool ShowPanelTitles);
