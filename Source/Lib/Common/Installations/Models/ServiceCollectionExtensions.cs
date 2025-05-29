using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.ComponentRenderers.Models;
using DevIn.Common.RazorLib.Contexts.Models;
using DevIn.Common.RazorLib.Keymaps.Models;
using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.Panels.Models;
using DevIn.Common.RazorLib.Widgets.Models;
using DevIn.Common.RazorLib.Notifications.Displays;
using DevIn.Common.RazorLib.TreeViews.Displays.Utils;
using DevIn.Common.RazorLib.WatchWindows.Displays;
using DevIn.Common.RazorLib.Dimensions.Models;
using DevIn.Common.RazorLib.Outlines.Models;
using DevIn.Common.RazorLib.Reflectives.Models;
using DevIn.Common.RazorLib.Drags.Models;
using DevIn.Common.RazorLib.Options.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Common.RazorLib.Dropdowns.Models;
using DevIn.Common.RazorLib.Notifications.Models;
using DevIn.Common.RazorLib.Clipboards.Models;
using DevIn.Common.RazorLib.Storages.Models;
using DevIn.Common.RazorLib.Dialogs.Models;
using DevIn.Common.RazorLib.Themes.Models;

namespace DevIn.Common.RazorLib.Installations.Models;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// The <see cref="configure"/> parameter provides an instance of a record type.
    /// Use the 'with' keyword to change properties and then return the new instance.
    /// </summary>
    public static IServiceCollection AddDevInCommonServices(
        this IServiceCollection services,
        DevInHostingInformation hostingInformation,
        Func<DevInCommonConfig, DevInCommonConfig>? configure = null)
    {
        var commonConfig = new DevInCommonConfig();

        if (configure is not null)
            commonConfig = configure.Invoke(commonConfig);

		var continuousQueue = new BackgroundTaskQueue(
            BackgroundTaskFacts.ContinuousQueueKey,
            "Continuous");
            
        var indefiniteQueue = new BackgroundTaskQueue(
            BackgroundTaskFacts.IndefiniteQueueKey,
            "Blocking");
            
        hostingInformation.BackgroundTaskService.SetContinuousQueue(continuousQueue);
        hostingInformation.BackgroundTaskService.SetIndefiniteQueue(indefiniteQueue);
            
        services
            .AddSingleton(commonConfig)
            .AddSingleton(hostingInformation)
            .AddSingleton<ICommonComponentRenderers>(_ => _commonRendererTypes)
			.AddScoped<BackgroundTaskService>(sp => 
            {
				hostingInformation.BackgroundTaskService.SetContinuousWorker(new ContinuousBackgroundTaskWorker(
				    continuousQueue,
					hostingInformation.BackgroundTaskService,
				    sp.GetRequiredService<ILoggerFactory>(),
				    hostingInformation.DevInHostingKind));

				hostingInformation.BackgroundTaskService.SetIndefiniteWorker(new IndefiniteBackgroundTaskWorker(
				    indefiniteQueue,
					hostingInformation.BackgroundTaskService,
				    sp.GetRequiredService<ILoggerFactory>(),
				    hostingInformation.DevInHostingKind));

				return hostingInformation.BackgroundTaskService;
			})
            .AddScoped<CommonBackgroundTaskApi>()
            .AddScoped<BrowserResizeInterop>()
            .AddScoped<IContextService, ContextService>()
            .AddScoped<IOutlineService, OutlineService>()
            .AddScoped<IPanelService, PanelService>()
            .AddScoped<IAppDimensionService, AppDimensionService>()
            .AddScoped<IKeymapService, KeymapService>()
            .AddScoped<IWidgetService, WidgetService>()
            .AddScoped<IReflectiveService, ReflectiveService>()
            .AddScoped<IClipboardService, JavaScriptInteropClipboardService>()
            .AddScoped<IDialogService, DialogService>()
            .AddScoped<INotificationService, NotificationService>()
            .AddScoped<IDragService, DragService>()
            .AddScoped<IDropdownService, DropdownService>()
            .AddScoped<IAppOptionsService, AppOptionsService>()
            .AddScoped<IStorageService, LocalStorageService>()
            .AddScoped<IThemeService, ThemeService>()
            .AddScoped<ITreeViewService, TreeViewService>();

        switch (hostingInformation.DevInHostingKind)
        {
            case DevInHostingKind.Photino:
                services.AddScoped<IEnvironmentProvider, LocalEnvironmentProvider>();
                services.AddScoped<IFileSystemProvider, LocalFileSystemProvider>();
                break;
            default:
                services.AddScoped<IEnvironmentProvider, InMemoryEnvironmentProvider>();
                services.AddScoped<IFileSystemProvider, InMemoryFileSystemProvider>();
                break;
        }
        
        return services;
    }

    private static readonly CommonTreeViews _commonTreeViews = new(
        typeof(TreeViewExceptionDisplay),
        typeof(TreeViewMissingRendererFallbackDisplay),
        typeof(TreeViewTextDisplay),
        typeof(TreeViewReflectionDisplay),
        typeof(TreeViewPropertiesDisplay),
        typeof(TreeViewInterfaceImplementationDisplay),
        typeof(TreeViewFieldsDisplay),
        typeof(TreeViewExceptionDisplay),
        typeof(TreeViewEnumerableDisplay));

    private static readonly CommonComponentRenderers _commonRendererTypes = new(
        typeof(CommonErrorNotificationDisplay),
        typeof(CommonInformativeNotificationDisplay),
        typeof(CommonProgressNotificationDisplay),
        _commonTreeViews);
}