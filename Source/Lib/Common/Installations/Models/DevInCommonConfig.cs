using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Themes.Models;

namespace DevIn.Common.RazorLib.Installations.Models;

/// <remarks>
/// This class is an exception to the naming convention, "don't use the word 'DevIn' in class names".
/// 
/// Reason for this exception: when one first starts interacting with this project,
/// 	this type might be one of the first types they interact with. So, the redundancy of namespace
/// 	and type containing 'DevIn' feels reasonable here.
/// </remarks>
public record DevInCommonConfig
{
	public DevInCommonConfig()
	{
	}

    /// <summary>The <see cref="Key{ThemeRecord}"/> to be used when the application starts</summary>
    public Key<ThemeRecord> InitialThemeKey { get; init; } = ThemeFacts.VisualStudioDarkThemeClone.Key;
    public string IsMaximizedStyleCssString { get; init; } = "width: 100vw; height: 100vh; left: 0; top: 0;";
}
