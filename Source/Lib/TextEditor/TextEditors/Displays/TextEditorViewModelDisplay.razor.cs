using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models.Internals;

namespace DevIn.TextEditor.RazorLib.TextEditors.Displays;

public partial class TextEditorViewModelDisplay : ComponentBase
{
	[Inject]
	private TextEditorService TextEditorService { get; set; } = null!;

	[Parameter, EditorRequired]
    public Key<TextEditorViewModel> TextEditorViewModelKey { get; set; } = Key<TextEditorViewModel>.Empty;
    
    [Parameter]
    public ViewModelDisplayOptions ViewModelDisplayOptions { get; set; } = new();

	private TextEditorViewModelSlimDisplay? _viewModelSlimDisplay;
	private TextEditorViewModelSlimDisplay? _viewModelSlimDisplayPrevious;
	private Key<TextEditorComponentData> _componentDataKey;
	
	private static string DictionaryKey => nameof(TextEditorComponentData.ComponentDataKey);

	public Dictionary<string, object?> DependentComponentParameters { get; set; } = new Dictionary<string, object?>
	{
		{
			DictionaryKey,
			null
		}
	};
	
	protected override void OnInitialized()
	{
		if (ViewModelDisplayOptions.TextEditorHtmlElementId == Guid.Empty)
			ViewModelDisplayOptions.TextEditorHtmlElementId = Guid.NewGuid();
			
		_componentDataKey = new Key<TextEditorComponentData>(ViewModelDisplayOptions.TextEditorHtmlElementId);
		DependentComponentParameters[DictionaryKey] = _componentDataKey;
		
		base.OnInitialized();
	}
}
