using DevIn.Extensions.DotNet.CompilerServices.Models;
using DevIn.Extensions.DotNet.ComponentRenderers.Models;
using Microsoft.AspNetCore.Components;

namespace DevIn.Extensions.DotNet.CompilerServices.Displays;

public partial class TreeViewCompilerServiceDisplay : ComponentBase, ITreeViewCompilerServiceRendererType
{
	[Parameter, EditorRequired]
	public TreeViewCompilerService TreeViewCompilerService { get; set; } = null!;
}