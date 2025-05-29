using Microsoft.Extensions.DependencyInjection;
using DevIn.Common.RazorLib.Installations.Models;
using DevIn.Common.RazorLib.Themes.Models;
using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.TextEditor.RazorLib.Installations.Models;
using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Ide.RazorLib.ComponentRenderers.Models;
using DevIn.Ide.RazorLib.CodeSearches.Models;
using DevIn.Ide.RazorLib.StartupControls.Models;
using DevIn.Ide.RazorLib.FileSystems.Models;
using DevIn.Ide.RazorLib.Menus.Models;
using DevIn.Ide.RazorLib.InputFiles.Displays;
using DevIn.Ide.RazorLib.InputFiles.Models;
using DevIn.Ide.RazorLib.FileSystems.Displays;
using DevIn.Ide.RazorLib.FormsGenerics.Displays;
using DevIn.Ide.RazorLib.Commands;
using DevIn.Ide.RazorLib.CommandBars.Models;
// FindAllReferences
// using DevIn.Ide.RazorLib.FindAllReferences.Models;
using DevIn.Ide.RazorLib.Shareds.Models;
using DevIn.Ide.RazorLib.BackgroundTasks.Models;
using DevIn.Ide.RazorLib.Terminals.Models;
using DevIn.Ide.RazorLib.FolderExplorers.Models;
using DevIn.Ide.RazorLib.Namespaces.Displays;
using DevIn.Ide.RazorLib.AppDatas.Models;

namespace DevIn.Ide.RazorLib.Installations.Models;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDevInIdeRazorLibServices(
        this IServiceCollection services,
        DevInHostingInformation hostingInformation,
        Func<DevInIdeConfig, DevInIdeConfig>? configure = null)
    {
        var ideConfig = new DevInIdeConfig();

        if (configure is not null)
            ideConfig = configure.Invoke(ideConfig);

        if (ideConfig.AddDevInTextEditor)
        {
            services.AddDevInTextEditor(hostingInformation, inTextEditorOptions => inTextEditorOptions with
            {
                CustomThemeRecordList = DevInTextEditorCustomThemeFacts.AllCustomThemesList,
                InitialThemeKey = ThemeFacts.VisualStudioDarkThemeClone.Key,
                AbsolutePathStandardizeFunc = AbsolutePathStandardizeFunc,
                FastParseFunc = async (fastParseArgs) =>
                {
                	var standardizedAbsolutePathString = await AbsolutePathStandardizeFunc(
                		fastParseArgs.ResourceUri.Value, fastParseArgs.ServiceProvider);
                		
                	var standardizedResourceUri = new ResourceUri(standardizedAbsolutePathString);
                
                    fastParseArgs = new FastParseArgs(
                        standardizedResourceUri,
                        fastParseArgs.ExtensionNoPeriod,
                        fastParseArgs.ServiceProvider)
                    {
                    	ShouldBlockUntilBackgroundTaskIsCompleted = fastParseArgs.ShouldBlockUntilBackgroundTaskIsCompleted
                    };

                    var ideBackgroundTaskApi = fastParseArgs.ServiceProvider.GetRequiredService<IdeBackgroundTaskApi>();
                    await ideBackgroundTaskApi.Editor_FastParseFunc(fastParseArgs);
                },
                RegisterModelFunc = async (registerModelArgs) =>
                {
                	var standardizedAbsolutePathString = await AbsolutePathStandardizeFunc(
                		registerModelArgs.ResourceUri.Value, registerModelArgs.ServiceProvider);
                		
                	var standardizedResourceUri = new ResourceUri(standardizedAbsolutePathString);
                
                    registerModelArgs = new RegisterModelArgs(
                    	registerModelArgs.EditContext,
                        standardizedResourceUri,
                        registerModelArgs.ServiceProvider)
                    {
                    	ShouldBlockUntilBackgroundTaskIsCompleted = registerModelArgs.ShouldBlockUntilBackgroundTaskIsCompleted
                    };

                    var ideBackgroundTaskApi = registerModelArgs.ServiceProvider.GetRequiredService<IdeBackgroundTaskApi>();
                    await ideBackgroundTaskApi.Editor_RegisterModelFunc(registerModelArgs);
                },
                TryRegisterViewModelFunc = async (tryRegisterViewModelArgs) =>
                {
                	var standardizedAbsolutePathString = await AbsolutePathStandardizeFunc(
                		tryRegisterViewModelArgs.ResourceUri.Value, tryRegisterViewModelArgs.ServiceProvider);
                		
                	var standardizedResourceUri = new ResourceUri(standardizedAbsolutePathString);
                	
                    tryRegisterViewModelArgs = new TryRegisterViewModelArgs(
                    	tryRegisterViewModelArgs.EditContext,
                        tryRegisterViewModelArgs.ViewModelKey,
                        standardizedResourceUri,
                        tryRegisterViewModelArgs.Category,
                        tryRegisterViewModelArgs.ShouldSetFocusToEditor,
                        tryRegisterViewModelArgs.ServiceProvider);

                    var ideBackgroundTaskApi = tryRegisterViewModelArgs.ServiceProvider.GetRequiredService<IdeBackgroundTaskApi>();
                    return await ideBackgroundTaskApi.Editor_TryRegisterViewModelFunc(tryRegisterViewModelArgs);
                },
                TryShowViewModelFunc = (tryShowViewModelArgs) =>
                {
                    var ideBackgroundTaskApi = tryShowViewModelArgs.ServiceProvider.GetRequiredService<IdeBackgroundTaskApi>();
                    return ideBackgroundTaskApi.Editor_TryShowViewModelFunc(tryShowViewModelArgs);
                },
            });
        }
        
        if (hostingInformation.DevInHostingKind == DevInHostingKind.Photino)
        	services.AddScoped<IAppDataService, NativeAppDataService>();
        else
        	services.AddScoped<IAppDataService, DoNothingAppDataService>();

        services
            .AddSingleton(ideConfig)
            .AddSingleton<IIdeComponentRenderers>(_ideComponentRenderers)
            .AddScoped<IdeBackgroundTaskApi>()
            .AddScoped<ICommandFactory, CommandFactory>()
            .AddScoped<IMenuOptionsFactory, MenuOptionsFactory>()
            .AddScoped<IFileTemplateProvider, FileTemplateProvider>()
            .AddScoped<ICodeSearchService, CodeSearchService>()
            .AddScoped<IInputFileService, InputFileService>()
            .AddScoped<IStartupControlService, StartupControlService>()
            .AddScoped<ITerminalService, TerminalService>()
            .AddScoped<ITerminalGroupService, TerminalGroupService>()
            .AddScoped<IFolderExplorerService, FolderExplorerService>()
            .AddScoped<IIdeMainLayoutService, IdeMainLayoutService>()
            .AddScoped<IIdeHeaderService, IdeHeaderService>()
            .AddScoped<ICommandBarService, CommandBarService>();
            // FindAllReferences
            // .AddScoped<IFindAllReferencesService, FindAllReferencesService>();

        return services;
    }
    
    public static Task<string> AbsolutePathStandardizeFunc(string absolutePathString, IServiceProvider serviceProvider)
    {
        var environmentProvider = serviceProvider.GetRequiredService<IEnvironmentProvider>();

        if (absolutePathString.StartsWith(environmentProvider.DriveExecutingFromNoDirectorySeparator))
        {
            var removeDriveFromResourceUriValue = absolutePathString[
                environmentProvider.DriveExecutingFromNoDirectorySeparator.Length..];

            return Task.FromResult(removeDriveFromResourceUriValue);
        }

        return Task.FromResult(absolutePathString);
    }

    private static readonly IdeTreeViews _ideTreeViews = new(
        typeof(TreeViewNamespacePathDisplay),
        typeof(TreeViewAbsolutePathDisplay));

    private static readonly IdeComponentRenderers _ideComponentRenderers = new(
        typeof(BooleanPromptOrCancelDisplay),
        typeof(FileFormDisplay),
        typeof(DeleteFileFormDisplay),
        typeof(InputFileDisplay),
        _ideTreeViews);
}