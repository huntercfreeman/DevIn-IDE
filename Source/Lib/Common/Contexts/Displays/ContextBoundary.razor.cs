using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DevIn.Common.RazorLib.Contexts.Models;
using DevIn.Common.RazorLib.Keymaps.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Outlines.Models;

namespace DevIn.Common.RazorLib.Contexts.Displays;

public partial class ContextBoundary : ComponentBase
{
    [Inject]
    private IContextService ContextService { get; set; } = null!;
    [Inject]
    private IOutlineService OutlineService { get; set; } = null!;

    [CascadingParameter]
    public ContextBoundary? ParentContextBoundary { get; set; }

    [Parameter, EditorRequired]
    public ContextRecord ContextRecord { get; set; } = default!;
    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = null!;

    [Parameter]
    public string ClassCssString { get; set; } = null!;
    [Parameter]
    public string StyleCssString { get; set; } = null!;
    [Parameter]
    public int TabIndex { get; set; } = -1;
    
    public void DispatchSetActiveContextStatesAction(List<Key<ContextRecord>> contextRecordKeyList)
    {
        contextRecordKeyList.Add(ContextRecord.ContextKey);

        if (ParentContextBoundary is not null)
            ParentContextBoundary.DispatchSetActiveContextStatesAction(contextRecordKeyList);
        else
            ContextService.SetFocusedContextHeirarchy(new(contextRecordKeyList));
    }
    
    /// <summary>NOTE: 'onfocus' event does not bubble, whereas 'onfocusin' does bubble. Usage of both events in this file is intentional.</summary>
    public void HandleOnFocus()
    {
    	OutlineService.SetOutline(
	    	ContextRecord.ContextElementId,
	    	null,
	    	true);
    }
    
    public void HandleOnBlur()
    {
    	OutlineService.SetOutline(
	    	null,
	    	null,
	    	false);
    }

    /// <summary>NOTE: 'onfocus' event does not bubble, whereas 'onfocusin' does bubble. Usage of both events in this file is intentional.</summary>
    public void HandleOnFocusIn()
    {
    	if (ContextService.GetContextState().FocusedContextHeirarchy.NearestAncestorKey != ContextRecord.ContextKey)
    		DispatchSetActiveContextStatesAction(new());
    }
    
    public Task HandleOnKeyDownAsync(KeyboardEventArgs keyboardEventArgs)
    {
        if (keyboardEventArgs.Key == "Shift" ||
            keyboardEventArgs.Key == "Control" ||
            keyboardEventArgs.Key == "Alt" ||
            keyboardEventArgs.Key == "Meta")
        {
            return Task.CompletedTask;
        }

        return HandleKeymapArgumentAsync(new (keyboardEventArgs));
    }

	/// <summary>
	/// (2025-01-24)
	/// ============
	/// Much of DevIn.Common was looked at for optimization.
	///
	/// Mostly excessive garbage collector overhead was looked for,
	/// class -> struct, kind of things.
	///
	/// But, after having finished, the next thing that stands out the most
	/// is this 'HandleKeymapArgumentAsync'.
	///
	/// Is it possible to 'short circuit' by caching known no-op keymap arguments?
	/// </summary>
    public async Task HandleKeymapArgumentAsync(KeymapArgs keymapArgs)
    {
        var success = ContextRecord.Keymap.MapFirstOrDefault(keymapArgs, out var command);

        if (success && command is not null)
            await command.CommandFunc(keymapArgs).ConfigureAwait(false);
        else if (ParentContextBoundary is not null)
            await ParentContextBoundary.HandleKeymapArgumentAsync(keymapArgs).ConfigureAwait(false);
    }

    public List<Key<ContextRecord>> GetContextBoundaryHeirarchy(List<Key<ContextRecord>> contextRecordKeyList)
    {
        contextRecordKeyList.Add(ContextRecord.ContextKey);

        if (ParentContextBoundary is not null)
            return ParentContextBoundary.GetContextBoundaryHeirarchy(contextRecordKeyList);
        else
            return contextRecordKeyList;
    }
}