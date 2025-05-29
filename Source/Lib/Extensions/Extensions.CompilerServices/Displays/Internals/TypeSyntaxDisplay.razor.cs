using Microsoft.AspNetCore.Components;
using DevIn.TextEditor.RazorLib;
using DevIn.Extensions.CompilerServices.Syntax;

namespace DevIn.Extensions.CompilerServices.Displays.Internals;

public partial class TypeSyntaxDisplay : ComponentBase
{
	[Inject]
	private TextEditorService TextEditorService { get; set; } = null!;
	
	[Parameter, EditorRequired]
	public SyntaxViewModel SyntaxViewModel { get; set; } = default!;
	
	[Parameter]
	public TypeReference TypeReference { get; set; } = default;
}