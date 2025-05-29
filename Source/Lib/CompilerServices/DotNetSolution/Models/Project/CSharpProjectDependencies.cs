using DevIn.Common.RazorLib.Namespaces.Models;

namespace DevIn.CompilerServices.DotNetSolution.Models.Project;

public class CSharpProjectDependencies
{
    public CSharpProjectDependencies(NamespacePath cSharpProjectNamespacePath)
    {
        CSharpProjectNamespacePath = cSharpProjectNamespacePath;
    }

    public NamespacePath CSharpProjectNamespacePath { get; }
}