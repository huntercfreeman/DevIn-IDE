using Microsoft.JSInterop;
using DevIn.Common.RazorLib.JavaScriptObjects.Models;
using DevIn.Common.RazorLib.Dimensions.Models;

namespace DevIn.Common.RazorLib.JsRuntimes.Models;

/// <remarks>
/// This class is an exception to the naming convention, "don't use the word 'DevIn' in class names".
/// 
/// Reason for this exception: the 'IJSRuntime' datatype is far more common in code,
/// 	than some specific type (example: DialogDisplay.razor).
///     So, adding 'DevIn' in the class name for redundancy seems meaningful here.
/// </remarks>
public class DevInCommonJavaScriptInteropApi
{
    private readonly IJSRuntime _jsRuntime;

    public DevInCommonJavaScriptInteropApi(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public ValueTask SubscribeWindowSizeChanged(DotNetObjectReference<BrowserResizeInterop> browserResizeInteropDotNetObjectReference)
    {
        return _jsRuntime.InvokeVoidAsync(
            "devInCommon.subscribeWindowSizeChanged",
            browserResizeInteropDotNetObjectReference);
    }

    public ValueTask DisposeWindowSizeChanged()
    {
        return _jsRuntime.InvokeVoidAsync(
            "devInCommon.disposeWindowSizeChanged");
    }
    
    public ValueTask FocusHtmlElementById(string elementId, bool preventScroll = false)
    {
        return _jsRuntime.InvokeVoidAsync(
            "devInCommon.focusHtmlElementById",
            elementId,
            preventScroll);
    }

    public ValueTask<bool> TryFocusHtmlElementById(string elementId)
    {
        return _jsRuntime.InvokeAsync<bool>(
            "devInCommon.tryFocusHtmlElementById",
            elementId);
    }
    
    public ValueTask<MeasuredHtmlElementDimensions> MeasureElementById(string elementId)
    {
        return _jsRuntime.InvokeAsync<MeasuredHtmlElementDimensions>(
            "devInCommon.measureElementById",
            elementId);
    }

    public ValueTask LocalStorageSetItem(string key, object? value)
    {
        return _jsRuntime.InvokeVoidAsync(
            "devInCommon.localStorageSetItem",
            key,
            value);
    }

    public ValueTask<string?> LocalStorageGetItem(string key)
    {
        return _jsRuntime.InvokeAsync<string?>(
            "devInCommon.localStorageGetItem",
            key);
    }

    public ValueTask<string> ReadClipboard()
    {
        return _jsRuntime.InvokeAsync<string>(
            "devInCommon.readClipboard");
    }

    public ValueTask SetClipboard(string value)
    {
        return _jsRuntime.InvokeVoidAsync(
            "devInCommon.setClipboard",
            value);
    }

    public ValueTask<ContextMenuFixedPosition> GetTreeViewContextMenuFixedPosition(
        string nodeElementId)
    {
        return _jsRuntime.InvokeAsync<ContextMenuFixedPosition>(
            "devInCommon.getTreeViewContextMenuFixedPosition",
            nodeElementId);
    }
}
