using DevIn.TextEditor.RazorLib.Options.Displays;

namespace DevIn.TextEditor.RazorLib.Installations.Models;

public struct SettingsDialogConfig
{
	public SettingsDialogConfig()
	{
	}

    public Type ComponentRendererType { get; init; } = typeof(TextEditorSettings);
    public bool ComponentIsResizable { get; init; } = true;
}
