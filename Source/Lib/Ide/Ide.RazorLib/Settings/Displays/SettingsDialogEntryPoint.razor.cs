using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Dialogs.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.Options.Models;

namespace DevIn.Ide.RazorLib.Settings.Displays;

public partial class SettingsDialogEntryPoint : ComponentBase
{
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;
    [Inject]
    private IDialogService DialogService { get; set; } = null!;

    private IDialog _dialogRecord = new DialogViewModel(
        Key<IDynamicViewModel>.NewKey(),
        "Settings",
        typeof(SettingsDisplay),
        null,
        null,
		true,
		null);

    public void DispatchRegisterDialogRecordAction() =>
        DialogService.ReduceRegisterAction(_dialogRecord);
}