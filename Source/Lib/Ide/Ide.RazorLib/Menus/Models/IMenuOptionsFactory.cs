using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.Notifications.Models;
using DevIn.Common.RazorLib.Menus.Models;
using DevIn.Common.RazorLib.Namespaces.Models;

namespace DevIn.Ide.RazorLib.Menus.Models;

public interface IMenuOptionsFactory
{
    public MenuOptionRecord NewEmptyFile(AbsolutePath parentDirectory, Func<Task> onAfterCompletion);
    public MenuOptionRecord NewTemplatedFile(NamespacePath parentDirectory, Func<Task> onAfterCompletion);
    public MenuOptionRecord NewDirectory(AbsolutePath parentDirectory, Func<Task> onAfterCompletion);
    public MenuOptionRecord DeleteFile(AbsolutePath absolutePath, Func<Task> onAfterCompletion);
    public MenuOptionRecord CopyFile(AbsolutePath absolutePath, Func<Task> onAfterCompletion);
    public MenuOptionRecord CutFile(AbsolutePath absolutePath, Func<Task> onAfterCompletion);

    public MenuOptionRecord RenameFile(
        AbsolutePath sourceAbsolutePath,
        INotificationService notificationService,
        Func<Task> onAfterCompletion);

    public MenuOptionRecord PasteClipboard(
        AbsolutePath directoryAbsolutePath,
        Func<Task> onAfterCompletion);
}