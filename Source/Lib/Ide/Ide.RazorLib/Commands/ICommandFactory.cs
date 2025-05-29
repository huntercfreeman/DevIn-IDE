using DevIn.Common.RazorLib.Dynamics.Models;

namespace DevIn.Ide.RazorLib.Commands;

public interface ICommandFactory
{
	public IDialog? CodeSearchDialog { get; set; }

    public void Initialize();
    public ValueTask OpenCodeSearchDialog();
}
