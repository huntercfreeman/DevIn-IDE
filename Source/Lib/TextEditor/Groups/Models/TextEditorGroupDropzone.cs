using DevIn.Common.RazorLib.Dimensions.Models;
using DevIn.Common.RazorLib.Dynamics.Models;
using DevIn.Common.RazorLib.JavaScriptObjects.Models;
using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.TextEditor.RazorLib.Groups.Models;

public class TextEditorGroupDropzone : IDropzone
{
    public TextEditorGroupDropzone(
        MeasuredHtmlElementDimensions measuredHtmlElementDimensions,
        Key<TextEditorGroup> textEditorGroupKey,
        ElementDimensions elementDimensions)
    {
        MeasuredHtmlElementDimensions = measuredHtmlElementDimensions;
        TextEditorGroupKey = textEditorGroupKey;
        ElementDimensions = elementDimensions;
    }

    public MeasuredHtmlElementDimensions MeasuredHtmlElementDimensions { get; }
    public Key<TextEditorGroup> TextEditorGroupKey { get; }
    public Key<IDropzone> DropzoneKey { get; }
    public ElementDimensions ElementDimensions { get; }
    public string CssClass { get; init; }
    public string CssStyle { get; }
}

