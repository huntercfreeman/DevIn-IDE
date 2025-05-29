using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Dimensions.Models;

namespace DevIn.Ide.RazorLib.Terminals.Models;

public interface ITerminalGroupService
{
	public event Action? TerminalGroupStateChanged;
	
	public TerminalGroupState GetTerminalGroupState();

    public void SetActiveTerminal(Key<ITerminal> terminalKey);
    public void InitializeResizeHandleDimensionUnit(DimensionUnit dimensionUnit);
}
