using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.Menus.Models;

namespace DevIn.Common.RazorLib.Contexts.Models;

public class ContextSwitchGroup
{
	public ContextSwitchGroup(
		Key<ContextSwitchGroup> key,
		string title,
		Func<Task<MenuRecord>> getMenuFunc)
	{
		Key = key;
		Title = title;
		GetMenuFunc = getMenuFunc;
	}

	public Key<ContextSwitchGroup> Key { get; }
	public string Title { get; }
	public Func<Task<MenuRecord>> GetMenuFunc { get; }
}
