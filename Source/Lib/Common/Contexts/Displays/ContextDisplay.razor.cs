using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Contexts.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Options.Models;

namespace DevIn.Common.RazorLib.Contexts.Displays;

public partial class ContextDisplay : ComponentBase
{
    [Inject]
    private IContextService ContextService { get; set; } = null!;
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;

    [Parameter, EditorRequired]
    public Key<ContextRecord> ContextKey { get; set; }

    private bool _isExpanded;
}