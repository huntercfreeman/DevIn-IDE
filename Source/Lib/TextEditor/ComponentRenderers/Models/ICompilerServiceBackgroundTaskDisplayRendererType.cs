using DevIn.Common.RazorLib.BackgroundTasks.Models;

namespace DevIn.TextEditor.RazorLib.ComponentRenderers.Models;

public interface ICompilerServiceBackgroundTaskDisplayRendererType
{
    public IBackgroundTaskGroup BackgroundTask { get; set; }
}