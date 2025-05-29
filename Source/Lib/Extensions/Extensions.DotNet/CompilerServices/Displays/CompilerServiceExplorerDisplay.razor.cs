using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Options.Models;

namespace DevIn.Extensions.DotNet.CompilerServices.Displays;

public partial class CompilerServiceExplorerDisplay : ComponentBase
{
	[Inject]
	private IAppOptionsService AppOptionsService { get; set; } = null!;
}
