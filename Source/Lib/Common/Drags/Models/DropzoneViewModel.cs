using DevIn.Common.RazorLib.Dimensions.Models;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.JavaScriptObjects.Models;
using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.Common.RazorLib.Drags.Models;

public record DropzoneViewModel(
		Key<IDropzone> Key,
		MeasuredHtmlElementDimensions MeasuredHtmlElementDimensions,
		ElementDimensions DropzoneElementDimensions,
        Key<IDropzone> DropzoneKey,
        ElementDimensions ElementDimensions,
        string CssClass,
        string CssStyle)
	: IDropzone;
