using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.TreeViews.Models;

namespace DevIn.Extensions.DotNet.Outputs.Models;

public record struct OutputState(Guid DotNetRunParseResultId)
{
	public static readonly Key<TreeViewContainer> TreeViewContainerKey = Key<TreeViewContainer>.NewKey();
	
	public OutputState() : this(Guid.Empty)
	{
	}
}
