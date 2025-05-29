using Microsoft.AspNetCore.Components;
using DevIn.Extensions.DotNet.DotNetSolutions.Models.Internals;

namespace DevIn.Extensions.DotNet.DotNetSolutions.Displays.Internals;

public partial class SolutionVisualizationSettingsDisplay : ComponentBase
{
	[Parameter, EditorRequired]
	public SolutionVisualizationModel SolutionVisualizationModel { get; set; } = null!;
}