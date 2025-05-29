using DevIn.Common.RazorLib.JsRuntimes.Models;
using Microsoft.JSInterop;

namespace DevIn.Common.RazorLib.Storages.Models;

public class LocalStorageService : IStorageService
{
    private readonly IJSRuntime _jsRuntime;

    public LocalStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    private DevInCommonJavaScriptInteropApi _jsRuntimeCommonApi;
	
	private DevInCommonJavaScriptInteropApi JsRuntimeCommonApi => _jsRuntimeCommonApi
		??= _jsRuntime.GetDevInCommonApi();

    public async ValueTask SetValue(string key, object? value)
    {
        await JsRuntimeCommonApi.LocalStorageSetItem(
                key,
                value)
            .ConfigureAwait(false);
    }

    public async ValueTask<object?> GetValue(string key)
    {
        return await JsRuntimeCommonApi.LocalStorageGetItem(
                key)
            .ConfigureAwait(false);
    }
}