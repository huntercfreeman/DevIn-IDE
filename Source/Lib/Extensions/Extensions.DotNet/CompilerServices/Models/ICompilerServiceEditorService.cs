using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;

namespace DevIn.Extensions.DotNet.CompilerServices.Models;

public interface ICompilerServiceEditorService
{
	public event Action? CompilerServiceEditorStateChanged;
	
	public CompilerServiceEditorState GetCompilerServiceEditorState();

    public void ReduceSetTextEditorViewModelKeyAction(Key<TextEditorViewModel> textEditorViewModelKey);
}
