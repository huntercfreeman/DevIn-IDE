using DevIn.Common.RazorLib.Contexts.Models;
using DevIn.Common.RazorLib.Dialogs.Models;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.BackgroundTasks.Models;

namespace DevIn.Common.RazorLib.Panels.Models;

public interface IPanelTab : ITab
{
    public Key<Panel> Key { get; }
    public Key<ContextRecord> ContextRecordKey { get; }
    public IPanelService PanelService { get; }
    public IDialogService DialogService { get; }
    public CommonBackgroundTaskApi CommonBackgroundTaskApi { get; }
}
