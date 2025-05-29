using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.Common.RazorLib.Themes.Models;

public interface IThemeService
{
	public event Action? ThemeStateChanged;
	
	public ThemeState GetThemeState();

    public void ReduceRegisterAction(ThemeRecord theme);
    public void ReduceDisposeAction(Key<ThemeRecord> themeKey);
}
