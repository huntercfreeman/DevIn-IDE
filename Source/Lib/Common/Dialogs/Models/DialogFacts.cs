using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.Common.RazorLib.Dialogs.Models;

public static class DialogFacts
{
    public static readonly Key<IDynamicViewModel> InputFileDialogKey = Key<IDynamicViewModel>.NewKey();
}