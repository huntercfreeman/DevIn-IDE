using Microsoft.JSInterop;

namespace DevIn.TextEditor.RazorLib.JsRuntimes.Models;

/// <remarks>
/// This class is an exception to the naming convention, "don't use the word 'DevIn' in class names".
/// 
/// Reason for this exception: the 'IJSRuntime' datatype is far more common in code,
/// 	than some specific type (example: DialogDisplay.razor).
///     So, adding 'DevIn' in the class name for redundancy seems meaningful here.
/// </remarks>
public static class DevInTextEditorJsRuntimeExtensionMethods
{
    public static DevInTextEditorJavaScriptInteropApi GetDevInTextEditorApi(this IJSRuntime jsRuntime)
    {
        return new DevInTextEditorJavaScriptInteropApi(jsRuntime);
    }
}