using DevIn.Ide.RazorLib.FileSystems.Models;

namespace DevIn.Ide.RazorLib.ComponentRenderers.Models;

public interface IFileFormRendererType
{
    public string FileName { get; set; }
    public bool IsDirectory { get; set; }
    public bool CheckForTemplates { get; set; }
    public Func<string, IFileTemplate?, List<IFileTemplate>, Task> OnAfterSubmitFunc { get; set; }
}