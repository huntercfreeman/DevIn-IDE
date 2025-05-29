using DevIn.Common.RazorLib.Commands.Models;
using DevIn.Common.RazorLib.Panels.Models;
using DevIn.Common.RazorLib.JsRuntimes.Models;

namespace DevIn.Common.RazorLib.Contexts.Models;

public static class ContextHelper
{
	/// <summary>
	/// TODO: BAD: Code duplication from 'DevIn.Ide.RazorLib.Commands.CommandFactory'
	/// </summary>
	public static CommandNoType ConstructFocusContextElementCommand(
        ContextRecord contextRecord,
        string displayName,
        string internalIdentifier,
        DevInCommonJavaScriptInteropApi jsRuntimeCommonApi,
        IPanelService panelService)
    {
        return new CommonCommand(
            displayName, internalIdentifier, false,
            async commandArgs =>
            {
                var success = await TrySetFocus().ConfigureAwait(false);

                if (!success)
                {
                    panelService.SetPanelTabAsActiveByContextRecordKey(
                        contextRecord.ContextKey);

                    _ = await TrySetFocus().ConfigureAwait(false);
                }
            });

        async Task<bool> TrySetFocus()
        {
            return await jsRuntimeCommonApi
                .TryFocusHtmlElementById(contextRecord.ContextElementId)
                .ConfigureAwait(false);
        }
    }
}
