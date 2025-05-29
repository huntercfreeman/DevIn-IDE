using DevIn.Common.RazorLib.Dimensions.Models;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.JavaScriptObjects.Models;
using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.Common.RazorLib.Panels.Models;

public record PanelGroupDropzone(
        MeasuredHtmlElementDimensions MeasuredHtmlElementDimensions,
        Key<PanelGroup> PanelGroupKey,
        ElementDimensions ElementDimensions,
        Key<IDropzone> DropzoneKey,
        string? CssClass,
        string? CssStyle)
	: IDropzone;
