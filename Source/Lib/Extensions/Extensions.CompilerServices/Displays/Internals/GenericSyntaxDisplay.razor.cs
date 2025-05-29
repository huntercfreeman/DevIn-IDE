using Microsoft.AspNetCore.Components;
using DevIn.Extensions.CompilerServices.Syntax;

namespace DevIn.Extensions.CompilerServices.Displays.Internals;

public partial class GenericSyntaxDisplay : ComponentBase
{
	[Parameter, EditorRequired]
	public SyntaxViewModel SyntaxViewModel { get; set; } = default!;
	
	[Parameter]
	public TypeReference TypeReference { get; set; } = default;
}