using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.Namespaces.Models;

namespace DevIn.CompilerServices.DotNetSolution.Models.Project;

public class CSharpProjectToProjectReference
{
    public CSharpProjectToProjectReference(
        NamespacePath modifyProjectNamespacePath,
        AbsolutePath referenceProjectAbsolutePath)
    {
        ModifyProjectNamespacePath = modifyProjectNamespacePath;
        ReferenceProjectAbsolutePath = referenceProjectAbsolutePath;
    }

    /// <summary>The <see cref="ModifyProjectNamespacePath"/> is the <see cref="NamespacePath"/> of the Project which will have its XML data modified.</summary>
    public NamespacePath ModifyProjectNamespacePath { get; }
    public AbsolutePath ReferenceProjectAbsolutePath { get; }
}