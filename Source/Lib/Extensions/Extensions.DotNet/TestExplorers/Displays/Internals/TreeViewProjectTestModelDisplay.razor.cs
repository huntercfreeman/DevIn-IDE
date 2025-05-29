using Microsoft.AspNetCore.Components;
using DevIn.Extensions.DotNet.TestExplorers.Models;

namespace DevIn.Extensions.DotNet.TestExplorers.Displays.Internals;

public partial class TreeViewProjectTestModelDisplay : ComponentBase
{
	[Parameter, EditorRequired]
	public TreeViewProjectTestModel TreeViewProjectTestModel { get; set; } = null!;
}