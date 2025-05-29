using DevIn.Common.RazorLib.Namespaces.Models;

namespace DevIn.CompilerServices.DotNetSolution.Models.Project;

public class CSharpProjectToProjectReferences
{
    public CSharpProjectToProjectReferences(NamespacePath cSharpProjectNamespacePath)
    {
        CSharpProjectNamespacePath = cSharpProjectNamespacePath;
    }

    public NamespacePath CSharpProjectNamespacePath { get; }
}