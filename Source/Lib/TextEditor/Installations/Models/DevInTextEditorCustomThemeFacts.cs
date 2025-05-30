using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Themes.Models;

namespace DevIn.TextEditor.RazorLib.Installations.Models;

/// <remarks>
/// This class is an exception to the naming convention, "don't use the word 'DevIn' in class names".
/// 
/// Reason for this exception: when one first starts interacting with this project,
/// 	this type might be one of the first types they interact with. So, the redundancy of namespace
/// 	and type containing 'DevIn' feels reasonable here.
/// </remarks>
public class DevInTextEditorCustomThemeFacts
{
    public static readonly ThemeRecord LightTheme = new ThemeRecord(
        new Key<ThemeRecord>(Guid.Parse("8165209b-0cea-45b4-b6dd-e5661b319c73")),
        "DevIn IDE Light Theme",
        "di_light-theme",
        ThemeContrastKind.Default,
        ThemeColorKind.Light,
        new ThemeScope[] { ThemeScope.TextEditor });

    public static readonly ThemeRecord DarkTheme = new ThemeRecord(
        new Key<ThemeRecord>(Guid.Parse("56d64327-03c2-48a3-b086-11b101826efb")),
        "DevIn IDE Dark Theme",
        "di_dark-theme",
        ThemeContrastKind.Default,
        ThemeColorKind.Dark,
        new ThemeScope[] { ThemeScope.TextEditor });

    public static readonly List<ThemeRecord> AllCustomThemesList = new()
    {
        LightTheme,
        DarkTheme
    };
}