using DevIn.Common.RazorLib.Namespaces.Models;

namespace DevIn.Ide.RazorLib.FileSystems.Models;

public class FileTemplateResult
{
    public FileTemplateResult(NamespacePath fileNamespacePath, string contents)
    {
        FileNamespacePath = fileNamespacePath;
        Contents = contents;
    }

    public NamespacePath FileNamespacePath { get; }
    public string Contents { get; }
}