using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Installations.Models;
using DevIn.TextEditor.RazorLib.Installations.Models;
using DevIn.Ide.RazorLib.Installations.Models;

namespace DevIn.Ide.RazorLib.Shareds.Displays.Internals;

public partial class IdeDevelopmentDisplay : ComponentBase
{
    private List<Type>? _commonTypeList;
    private List<Type>? _textEditorTypeList;
    private List<Type>? _compilerServicesTypeList;
    private List<Type>? _ideTypeList;

    private ProjectKind _projectKind = ProjectKind.Common;
    private Type? _projectComponentType;

    private List<Type> GetProjectComponentTypeList(ProjectKind projectKind)
    {
        switch (projectKind)
        {
            case ProjectKind.Common:
                return _commonTypeList ??= typeof(DevInCommonConfig).Assembly.GetTypes()
                    .Where(x => x.IsSubclassOf(typeof(ComponentBase))).OrderBy(x => x.Name).ToList();
            case ProjectKind.TextEditor:
                return _textEditorTypeList ??= typeof(DevInTextEditorConfig).Assembly.GetTypes()
                    .Where(x => x.IsSubclassOf(typeof(ComponentBase))).OrderBy(x => x.Name).ToList();
            case ProjectKind.CompilerServices:
                return _compilerServicesTypeList ??= typeof(DevInCommonConfig).Assembly.GetTypes()
                    .Where(x => x.IsSubclassOf(typeof(ComponentBase))).OrderBy(x => x.Name).ToList();
            case ProjectKind.Ide:
                return _ideTypeList ??= typeof(DevInIdeConfig).Assembly.GetTypes()
                    .Where(x => x.IsSubclassOf(typeof(ComponentBase))).OrderBy(x => x.Name).ToList();
            default:
                return new List<Type>();
        }
    }

    private string GetIsActiveCssClass(ProjectKind projectKind)
    {
        return _projectKind == projectKind
            ? "di_active"
            : string.Empty;
    }

    private void SetProjectKindOnClick(ProjectKind projectKind)
    {
        _projectKind = projectKind;
    }
    
    private void SetProjectComponentTypeOnClick(Type projectComponentType)
    {
        _projectComponentType = projectComponentType;
    }

    public enum ProjectKind
    {
        Common,
        TextEditor,
        CompilerServices,
        Ide
    }
}