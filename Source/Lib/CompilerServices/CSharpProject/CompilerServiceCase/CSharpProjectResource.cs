using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.CompilerServices.CSharpProject.CompilerServiceCase;

public class CSharpProjectResource : CompilerServiceResource
{
    public CSharpProjectResource(ResourceUri resourceUri, CSharpProjectCompilerService cSharpProjectCompilerService)
        : base(resourceUri, cSharpProjectCompilerService)
    {
    }
}