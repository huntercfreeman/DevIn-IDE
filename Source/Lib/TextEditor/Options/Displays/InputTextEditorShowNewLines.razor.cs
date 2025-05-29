using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Options.Models;

namespace DevIn.TextEditor.RazorLib.Options.Displays;

public partial class InputTextEditorShowNewLines : ComponentBase, IDisposable
{
    [Inject]
    private TextEditorService TextEditorService { get; set; } = null!;

    [Parameter]
    public InputViewModel InputViewModel { get; set; } = InputViewModel.Empty;

    public bool GlobalShowNewlines
    {
        get => TextEditorService.OptionsApi.GetTextEditorOptionsState().Options.ShowNewlines;
        set => TextEditorService.OptionsApi.SetShowNewlines(value);
    }
    
    protected override void OnInitialized()
    {
    	TextEditorService.OptionsApi.StaticStateChanged += TextEditorOptionsStateWrapOnStateChanged;
    	base.OnInitialized();
    }
    
    private async void TextEditorOptionsStateWrapOnStateChanged()
    {
        await InvokeAsync(StateHasChanged);
    }
    
    public void Dispose()
    {
    	TextEditorService.OptionsApi.StaticStateChanged -= TextEditorOptionsStateWrapOnStateChanged;
    }
}