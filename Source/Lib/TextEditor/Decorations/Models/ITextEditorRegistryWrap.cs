using DevIn.TextEditor.RazorLib.CompilerServices;

namespace DevIn.TextEditor.RazorLib.Decorations.Models;

public interface ITextEditorRegistryWrap
{
    public IDecorationMapperRegistry DecorationMapperRegistry { get; set; }
    public ICompilerServiceRegistry CompilerServiceRegistry { get; set; }
}
