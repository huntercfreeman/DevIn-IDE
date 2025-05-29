using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.TextEditor.RazorLib.CompilerServices;

public class CompilerServiceResource : ICompilerServiceResource
{
    public CompilerServiceResource(
        ResourceUri resourceUri,
        ICompilerService compilerService)
    {
        ResourceUri = resourceUri;
        CompilerService = compilerService;
    }

    public virtual ResourceUri ResourceUri { get; }
    public virtual ICompilerService CompilerService { get; }
    public virtual ICompilationUnit CompilationUnit { get; set; }
}
