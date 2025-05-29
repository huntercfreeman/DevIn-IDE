using DevIn.Common.RazorLib.ComponentRenderers.Models;
using DevIn.Common.RazorLib.TreeViews.Models;

namespace DevIn.Common.RazorLib.WatchWindows.Models;

public class TreeViewInterfaceImplementation : TreeViewReflection
{
    private readonly ICommonComponentRenderers _commonComponentRenderers;

    public TreeViewInterfaceImplementation(
            WatchWindowObject watchWindowObject,
            bool isExpandable,
            bool isExpanded,
            ICommonComponentRenderers commonComponentRenderers)
        : base(watchWindowObject, isExpandable, isExpanded, commonComponentRenderers)
    {
        _commonComponentRenderers = commonComponentRenderers;
    }

    public override TreeViewRenderer GetTreeViewRenderer()
    {
        return new TreeViewRenderer(
            _commonComponentRenderers.CommonTreeViews.TreeViewInterfaceImplementationRenderer,
            new Dictionary<string, object?>
            {
                {
                    nameof(TreeViewInterfaceImplementation),
                    this
                },
            });
    }
}