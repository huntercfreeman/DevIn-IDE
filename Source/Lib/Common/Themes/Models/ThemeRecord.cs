using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.Common.RazorLib.Themes.Models;

public record ThemeRecord(
    Key<ThemeRecord> Key,
    string DisplayName,
    string CssClassString,
    ThemeContrastKind ThemeContrastKind,
    ThemeColorKind ThemeColorKind,
    IReadOnlyList<ThemeScope> ThemeScopeList);