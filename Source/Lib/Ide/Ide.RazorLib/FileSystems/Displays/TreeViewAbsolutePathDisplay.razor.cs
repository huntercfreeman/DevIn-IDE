using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Ide.RazorLib.ComponentRenderers.Models;
using DevIn.Ide.RazorLib.FileSystems.Models;
using Microsoft.AspNetCore.Components;

namespace DevIn.Ide.RazorLib.FileSystems.Displays;

public partial class TreeViewAbsolutePathDisplay : ComponentBase, ITreeViewAbsolutePathRendererType
{
    [CascadingParameter]
    public TreeViewContainer TreeViewState { get; set; } = null!;
    [CascadingParameter(Name = "SearchQuery")]
    public string SearchQuery { get; set; } = string.Empty;
    [CascadingParameter(Name = "SearchMatchTuples")]
    public List<(Key<TreeViewContainer> treeViewStateKey, TreeViewAbsolutePath treeViewAbsolutePath)>? SearchMatchTuples { get; set; }

    [Parameter, EditorRequired]
    public TreeViewAbsolutePath TreeViewAbsolutePath { get; set; } = null!;
}