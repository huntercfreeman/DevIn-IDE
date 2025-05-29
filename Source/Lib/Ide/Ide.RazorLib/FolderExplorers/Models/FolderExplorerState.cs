using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.Ide.RazorLib.FolderExplorers.Models;

public record struct FolderExplorerState(
    AbsolutePath? AbsolutePath,
    bool IsLoadingFolderExplorer)
{
    public static readonly Key<TreeViewContainer> TreeViewContentStateKey = Key<TreeViewContainer>.NewKey();

    public FolderExplorerState() : this(
        default,
        false)
    {

    }
}