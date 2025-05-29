using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.Namespaces.Models;

namespace DevIn.Ide.RazorLib.FileSystems.Models;

public class FileTemplateParameter
{
    public FileTemplateParameter(
        string filename,
        NamespacePath parentDirectory,
        IEnvironmentProvider environmentProvider)
    {
        Filename = filename;
        ParentDirectory = parentDirectory;
        EnvironmentProvider = environmentProvider;
    }

    public string Filename { get; }
    public NamespacePath ParentDirectory { get; }
    public IEnvironmentProvider EnvironmentProvider { get; }
}