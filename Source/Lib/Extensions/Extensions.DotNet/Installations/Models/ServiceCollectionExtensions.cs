using Microsoft.Extensions.DependencyInjection;
using DevIn.Common.RazorLib.Installations.Models;
using DevIn.Ide.RazorLib.Installations.Models;
using DevIn.Extensions.DotNet.CSharpProjects.Displays;
using DevIn.Extensions.DotNet.DotNetSolutions.Displays;
using DevIn.Extensions.DotNet.Menus.Models;
using DevIn.Extensions.DotNet.Nugets.Models;
using DevIn.Extensions.DotNet.ComponentRenderers.Models;
using DevIn.Extensions.DotNet.Nugets.Displays;
using DevIn.Extensions.DotNet.CommandLines.Models;
using DevIn.Extensions.DotNet.BackgroundTasks.Models;
using DevIn.Extensions.DotNet.CompilerServices.Displays;
using DevIn.Extensions.DotNet.Commands;

namespace DevIn.Extensions.DotNet.Installations.Models;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddDevInExtensionsDotNetServices(
		this IServiceCollection services,
		DevInHostingInformation hostingInformation,
		Func<DevInIdeConfig, DevInIdeConfig>? configure = null)
	{
		return services
			.AddScoped<INugetPackageManagerProvider, NugetPackageManagerProviderAzureSearchUsnc>()
			.AddScoped<DotNetCliOutputParser>()
			.AddScoped<DotNetBackgroundTaskApi>()
			.AddScoped<IDotNetCommandFactory, DotNetCommandFactory>()
			.AddScoped<IDotNetMenuOptionsFactory, DotNetMenuOptionsFactory>()
			.AddScoped<IDotNetComponentRenderers>(_ => _dotNetComponentRenderers);
	}

	private static readonly CompilerServicesTreeViews _dotNetTreeViews = new(
		typeof(TreeViewCSharpProjectDependenciesDisplay),
		typeof(TreeViewCSharpProjectNugetPackageReferencesDisplay),
		typeof(TreeViewCSharpProjectToProjectReferencesDisplay),
		typeof(TreeViewCSharpProjectNugetPackageReferenceDisplay),
		typeof(TreeViewCSharpProjectToProjectReferenceDisplay),
		typeof(TreeViewSolutionFolderDisplay),
        typeof(TreeViewCompilerServiceDisplay));

	private static readonly DotNetComponentRenderers _dotNetComponentRenderers = new(
		typeof(NuGetPackageManager),
		typeof(RemoveCSharpProjectFromSolutionDisplay),
		_dotNetTreeViews);
}