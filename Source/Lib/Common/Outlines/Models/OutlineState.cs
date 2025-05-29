using DevIn.Common.RazorLib.JavaScriptObjects.Models;

namespace DevIn.Common.RazorLib.Outlines.Models;

public record struct OutlineState(
	string? ElementId,
	MeasuredHtmlElementDimensions? MeasuredHtmlElementDimensions,
	bool NeedsMeasured)
{
	public OutlineState() : this(null, null, false)
	{
	}
}
