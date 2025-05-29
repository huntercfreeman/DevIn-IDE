using Microsoft.JSInterop;
using DevIn.Common.RazorLib.JavaScriptObjects.Models;
using DevIn.TextEditor.RazorLib.JavaScriptObjects.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;

namespace DevIn.TextEditor.RazorLib.JsRuntimes.Models;

/// <remarks>
/// This class is an exception to the naming convention, "don't use the word 'DevIn' in class names".
/// 
/// Reason for this exception: the 'IJSRuntime' datatype is far more common in code,
/// 	than some specific type (example: DialogDisplay.razor).
///     So, adding 'DevIn' in the class name for redundancy seems meaningful here.
/// </remarks>
public class DevInTextEditorJavaScriptInteropApi
{
    private readonly IJSRuntime _jsRuntime;

    public DevInTextEditorJavaScriptInteropApi(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public ValueTask ScrollElementIntoView(string elementId)
    {
        return _jsRuntime.InvokeVoidAsync(
            "devInTextEditor.scrollElementIntoView",
            elementId);
    }

    public ValueTask PreventDefaultOnWheelEvents(string elementId)
    {
        return _jsRuntime.InvokeVoidAsync(
            "devInTextEditor.preventDefaultOnWheelEvents",
            elementId);
    }

    public ValueTask<CharAndLineMeasurements> GetCharAndLineMeasurementsInPixelsById(
        string measureCharacterWidthAndLineHeightElementId,
        int countOfTestCharacters)
    {
        return _jsRuntime.InvokeAsync<CharAndLineMeasurements>(
            "devInTextEditor.getCharAndLineMeasurementsInPixelsById",
            measureCharacterWidthAndLineHeightElementId,
            countOfTestCharacters);
    }

    /// <summary>
    /// TODO: This javascript function is only used from other javascript functions.
    /// </summary>
    public ValueTask<string> EscapeHtml(string input)
    {
        return _jsRuntime.InvokeAsync<string>(
            "devInTextEditor.escapeHtml",
            input);
    }

    public ValueTask<RelativeCoordinates> GetRelativePosition(
        string elementId,
        double clientX,
        double clientY)
    {
        return _jsRuntime.InvokeAsync<RelativeCoordinates>(
            "devInTextEditor.getRelativePosition",
            elementId,
            clientX,
            clientY);
    }

    public ValueTask SetScrollPositionBoth(
        string bodyElementId,
        double scrollLeftInPixels,
        double scrollTopInPixels)
    {
        return _jsRuntime.InvokeVoidAsync(
            "devInTextEditor.setScrollPositionBoth",
            bodyElementId,
            scrollLeftInPixels,
            scrollTopInPixels);
    }
    
    public ValueTask SetScrollPositionLeft(
        string bodyElementId,
        double scrollLeftInPixels)
    {
        return _jsRuntime.InvokeVoidAsync(
            "devInTextEditor.setScrollPositionLeft",
            bodyElementId,
            scrollLeftInPixels);
    }
    
    public ValueTask SetScrollPositionTop(
        string bodyElementId,
        double scrollTopInPixels)
    {
        return _jsRuntime.InvokeVoidAsync(
            "devInTextEditor.setScrollPositionTop",
            bodyElementId,
            scrollTopInPixels);
    }

    public ValueTask<TextEditorDimensions> GetTextEditorMeasurementsInPixelsById(
        string elementId)
    {
        return _jsRuntime.InvokeAsync<TextEditorDimensions>(
            "devInTextEditor.getTextEditorMeasurementsInPixelsById",
            elementId);
    }

    public ValueTask<ElementPositionInPixels> GetBoundingClientRect(string primaryCursorContentId)
    {
        return _jsRuntime.InvokeAsync<ElementPositionInPixels>(
            "devInTextEditor.getBoundingClientRect",
            primaryCursorContentId);
    }
}
