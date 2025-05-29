using DevIn.Common.RazorLib.Dimensions.Models;
using DevIn.Common.RazorLib.JavaScriptObjects.Models;
using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.Common.RazorLib.Dynamics.Models;

public interface IDropzone
{
    public Key<IDropzone> DropzoneKey { get; }
    public MeasuredHtmlElementDimensions MeasuredHtmlElementDimensions { get; }
    public ElementDimensions ElementDimensions { get; }
    public string? CssClass { get; }
    public string? CssStyle { get; }
}
