namespace DevIn.Ide.RazorLib.BackgroundTasks.Models;

public enum IdeBackgroundTaskApiWorkKind
{
	None,
    DevInIdeInitializerOnInit,
    IdeHeaderOnInit,
    FileContentsWereModifiedOnDisk,
    SaveFile,
    SetFolderExplorerState,
    SetFolderExplorerTreeView,
    RequestInputFileStateForm,
}
