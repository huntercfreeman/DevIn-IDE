using DevIn.Common.RazorLib.Keys.Models;
using DevIn.CompilerServices.DotNetSolution.Models;
using DevIn.Extensions.DotNet.BackgroundTasks.Models;

namespace DevIn.Extensions.DotNet.DotNetSolutions.Models;

public interface IDotNetSolutionService
{
	public event Action? DotNetSolutionStateChanged;
	
	public DotNetSolutionState GetDotNetSolutionState();

    public void ReduceRegisterAction(DotNetSolutionModel dotNetSolutionModel);

    public void ReduceDisposeAction(Key<DotNetSolutionModel> dotNetSolutionModelKey);

    public void ReduceWithAction(DotNetBackgroundTaskApi.IWithAction withActionInterface);
    
	public Task NotifyDotNetSolutionStateStateHasChanged();
}
