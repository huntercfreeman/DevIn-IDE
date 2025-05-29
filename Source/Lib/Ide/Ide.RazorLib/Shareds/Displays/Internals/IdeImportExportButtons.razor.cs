using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Dialogs.Models;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.Ide.RazorLib.Shareds.Displays.Internals;

public partial class IdeImportExportButtons : ComponentBase
{
    [Inject]
    private IDialogService DialogService { get; set; } = null!;

    private IDialog _importDialogRecord = new DialogViewModel(
        Key<IDynamicViewModel>.NewKey(),
        "Import",
        typeof(IdeImportDisplay),
        null,
        null,
		true,
		null);

    private IDialog _exportDialogRecord = new DialogViewModel(
        Key<IDynamicViewModel>.NewKey(),
        "Export",
        typeof(IdeExportDisplay),
        null,
        null,
		true,
		null);

    private void ImportOnClick()
    {
        DialogService.ReduceRegisterAction(_importDialogRecord);
    }
}