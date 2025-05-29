using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Options.Models;

namespace DevIn.Extensions.DotNet.Outputs.Displays;

public partial class OutputPanelDisplay : ComponentBase
{
	[Inject]
	private IAppOptionsService AppOptionsService { get; set; } = null!;
}