using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.Common.RazorLib.Contexts.Models;

public partial record ContextSwitchState(IReadOnlyList<ContextSwitchGroup> ContextSwitchGroupList)
{
	public ContextSwitchState() : this(new List<ContextSwitchGroup>())
	{
	}
	
	/// <summary>
	/// After the UI renders, which of the entries in <see cref="ContextSwitchGroupList"/>
	/// should have their 0th menu option set focused first.
	/// </summary>
	public Key<ContextSwitchGroup> FocusInitiallyContextSwitchGroupKey { get; set; }
}
