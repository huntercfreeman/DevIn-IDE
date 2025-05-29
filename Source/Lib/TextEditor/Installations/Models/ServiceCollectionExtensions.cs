using Microsoft.Extensions.DependencyInjection;
using DevIn.Common.RazorLib.Installations.Models;
using DevIn.TextEditor.RazorLib.Autocompletes.Models;
using DevIn.TextEditor.RazorLib.ComponentRenderers.Models;
using DevIn.TextEditor.RazorLib.Decorations.Models;
using DevIn.TextEditor.RazorLib.TextEditors.Models;
using DevIn.TextEditor.RazorLib.FindAlls.Models;
using DevIn.TextEditor.RazorLib.Edits.Models;

namespace DevIn.TextEditor.RazorLib.Installations.Models;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDevInTextEditor(
        this IServiceCollection services,
        DevInHostingInformation hostingInformation,
        Func<DevInTextEditorConfig, DevInTextEditorConfig>? configure = null)
    {
        var textEditorConfig = new DevInTextEditorConfig();

        if (configure is not null)
            textEditorConfig = configure.Invoke(textEditorConfig);

        if (textEditorConfig.AddDevInCommon)
            services.AddDevInCommonServices(hostingInformation);

        services
            .AddSingleton(textEditorConfig)
            .AddSingleton<IDevInTextEditorComponentRenderers>(_textEditorComponentRenderers)
            .AddScoped<IAutocompleteService, WordAutocompleteService>()
            .AddScoped<IAutocompleteIndexer, WordAutocompleteIndexer>()
            .AddScoped<TextEditorService>()
            .AddScoped<ITextEditorRegistryWrap, TextEditorRegistryWrap>()
            .AddScoped<ITextEditorHeaderRegistry, TextEditorHeaderRegistry>()
            .AddScoped<IFindAllService, FindAllService>()
            .AddScoped<IDirtyResourceUriService, DirtyResourceUriService>();
        
        return services;
    }

    private static readonly DevInTextEditorComponentRenderers _textEditorComponentRenderers = new(
        typeof(TextEditors.Displays.Internals.DiagnosticDisplay));
}