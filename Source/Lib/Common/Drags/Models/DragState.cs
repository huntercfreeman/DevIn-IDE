using Microsoft.AspNetCore.Components.Web;
using DevIn.Common.RazorLib.Dynamics.Models;

namespace DevIn.Common.RazorLib.Drags.Models;

public record struct DragState(
    bool ShouldDisplay,
    MouseEventArgs? MouseEventArgs,
	IDrag? Drag)
{
    public DragState() : this (false, null, null)
    {
        
    }
}