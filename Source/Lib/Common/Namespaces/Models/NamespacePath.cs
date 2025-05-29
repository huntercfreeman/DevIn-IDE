using DevIn.Common.RazorLib.FileSystems.Models;

namespace DevIn.Common.RazorLib.Namespaces.Models;

/// <summary>
/// Verify 'Namespace' is not null to know whether this was constructed or default.
/// 
/// TODO: Move this type somehere else. This type currently exists in 'DevIn.Common.csproj'...
/// ...because the 'DevIn.CompilerServices.DotNetSolution.csproj' needed to reference the type.<br/>
/// |<br/>
/// And with it having originally been in 'DevIn.Ide.csproj', this meant a circular
/// reference and it had to be moved here for now.
/// </summary>
public struct NamespacePath
{
    public NamespacePath(string namespaceString, AbsolutePath absolutePath)
    {
        Namespace = namespaceString;
        AbsolutePath = absolutePath;
    }

    public string Namespace { get; }
    public AbsolutePath AbsolutePath { get; }
}