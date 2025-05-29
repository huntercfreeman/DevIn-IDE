using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;
using DevIn.Ide.RazorLib.InputFiles.Models;
using DevIn.Ide.RazorLib.Shareds.Displays;

namespace DevIn.Ide.RazorLib.BackgroundTasks.Models;

/*
These IBackgroundTaskGroup "args" structs are a bit heavy at the moment.
This is better than how things were, I need to find another moment
to go through and lean these out.
*/
public struct IdeBackgroundTaskApiWorkArgs
{
	public IdeBackgroundTaskApiWorkKind WorkKind { get; set; }
    public IdeHeader IdeHeader { get; set; }
    public string InputFileAbsolutePathString { get; set; }
    public TextEditorModel TextEditorModel { get; set; }
    public DateTime FileLastWriteTime { get; set; }
    public Key<IDynamicViewModel> NotificationInformativeKey { get; set; }
    public AbsolutePath AbsolutePath { get; set; }
    public string Content { get; set; }
    public Func<DateTime?, Task> OnAfterSaveCompletedWrittenDateTimeFunc { get; set; }
    public CancellationToken CancellationToken { get; set; }
    
    public string Message { get; set; }
    public Func<AbsolutePath, Task> OnAfterSubmitFunc { get; set; }
    public Func<AbsolutePath, Task<bool>> SelectionIsValidFunc { get; set; }
    public List<InputFilePattern> InputFilePatterns { get; set; }
}
