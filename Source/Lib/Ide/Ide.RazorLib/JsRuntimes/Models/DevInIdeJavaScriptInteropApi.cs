using Microsoft.JSInterop;

namespace DevIn.Ide.RazorLib.JsRuntimes.Models;

/// <remarks>
/// This class is an exception to the naming convention, "don't use the word 'DevIn' in class names".
/// 
/// Reason for this exception: the 'IJSRuntime' datatype is far more common in code,
/// 	than some specific type (example: DialogDisplay.razor).
///     So, adding 'DevIn' in the class name for redundancy seems meaningful here.
/// </remarks>
public class DevInIdeJavaScriptInteropApi
{
    private readonly IJSRuntime _jsRuntime;

    public DevInIdeJavaScriptInteropApi(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    /// <summary>
    /// This function is intended to only be invoked
	/// from C# when the DevInHostingKind is Photino.<br/><br/>
	///
	/// Because when running the native application,
	/// the fact that, for example, 'F5' refreshes
	/// the native application is very frustrating.
    /// </summary>
    public ValueTask PreventDefaultBrowserKeybindings()
    {
        return _jsRuntime.InvokeVoidAsync(
            "devInIde.preventDefaultBrowserKeybindings");
    }
}
