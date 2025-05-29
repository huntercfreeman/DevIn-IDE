namespace DevIn.TextEditor.RazorLib.ComponentRenderers.Models;

public class DevInTextEditorComponentRenderers : IDevInTextEditorComponentRenderers
{
    public DevInTextEditorComponentRenderers(Type diagnosticRendererType)
    {
        DiagnosticRendererType = diagnosticRendererType;
    }

    public Type DiagnosticRendererType { get; }
}