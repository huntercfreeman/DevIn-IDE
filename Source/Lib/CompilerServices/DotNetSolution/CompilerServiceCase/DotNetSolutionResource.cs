using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.TextEditor.RazorLib.CompilerServices;

namespace DevIn.CompilerServices.DotNetSolution.CompilerServiceCase;

public class DotNetSolutionResource : CompilerServiceResource
{
    public DotNetSolutionResource(ResourceUri resourceUri, DotNetSolutionCompilerService dotNetSolutionCompilerService)
        : base(resourceUri, dotNetSolutionCompilerService)
    {
    }
}