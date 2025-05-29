using Microsoft.AspNetCore.Components;
using DevIn.Extensions.DotNet.Outputs.Models;

namespace DevIn.Extensions.DotNet.Outputs.Displays.Internals;

public partial class TreeViewDiagnosticLineDisplay : ComponentBase
{
	[Parameter, EditorRequired]
	public TreeViewDiagnosticLine TreeViewDiagnosticLine { get; set; } = null!;
}