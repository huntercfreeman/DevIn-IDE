using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;

namespace DevIn.Extensions.DotNet.CompilerServices.Models;

public class CompilerServiceEditorService : ICompilerServiceEditorService
{
	private CompilerServiceEditorState _compilerServiceEditorState = new();
	
	public event Action? CompilerServiceEditorStateChanged;
	
	public CompilerServiceEditorState GetCompilerServiceEditorState() => _compilerServiceEditorState;

    public void ReduceSetTextEditorViewModelKeyAction(Key<TextEditorViewModel> textEditorViewModelKey)
    {
    	var inState = GetCompilerServiceEditorState();
    
        _compilerServiceEditorState = inState with
        { 
            TextEditorViewModelKey = textEditorViewModelKey
        };
        
        CompilerServiceEditorStateChanged?.Invoke();
        return;
    }
}
