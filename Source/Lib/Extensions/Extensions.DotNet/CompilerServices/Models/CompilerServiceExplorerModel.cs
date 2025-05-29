using DevIn.Common.RazorLib.FileSystems.Models;

namespace DevIn.Extensions.DotNet.CompilerServices.Models;

public class CompilerServiceExplorerModel
{
	public AbsolutePath? AbsolutePath { get; }
	public bool IsLoadingCompilerServiceExplorer { get; }
}
