using Microsoft.AspNetCore.Components.Web;
using DevIn.Common.RazorLib.Dynamics.Models;

namespace DevIn.Common.RazorLib.Drags.Models;

public interface IDragService
{
	public event Action? DragStateChanged;
	
    public DragState GetDragState();
    
    public void ReduceShouldDisplayAndMouseEventArgsSetAction(
        bool shouldDisplay,
        MouseEventArgs? mouseEventArgs);
    
    public void ReduceShouldDisplayAndMouseEventArgsAndDragSetAction(
        bool shouldDisplay,
		MouseEventArgs? mouseEventArgs,
		IDrag? drag);
}