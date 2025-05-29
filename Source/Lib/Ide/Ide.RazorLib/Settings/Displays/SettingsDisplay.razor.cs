using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib;

namespace DevIn.Ide.RazorLib.Settings.Displays;

public partial class SettingsDisplay : ComponentBase
{
	[Inject]
	private TextEditorService TextEditorService { get; set; } = null!;

    public static readonly Key<IDynamicViewModel> SettingsDialogKey = Key<IDynamicViewModel>.NewKey();
}