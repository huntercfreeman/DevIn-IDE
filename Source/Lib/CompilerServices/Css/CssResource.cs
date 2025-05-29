using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.CompilerServices.Css;

public class CssResource : CompilerServiceResource
{
    public CssResource(ResourceUri resourceUri, CssCompilerService textEditorCssCompilerService)
        : base(resourceUri, textEditorCssCompilerService)
    {
    }
}