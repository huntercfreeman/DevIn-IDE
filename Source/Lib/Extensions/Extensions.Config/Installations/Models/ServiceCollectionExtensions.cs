using Microsoft.Extensions.DependencyInjection;
using DevIn.Common.RazorLib.Installations.Models;
using DevIn.TextEditor.RazorLib.Decorations.Models;
using DevIn.Ide.RazorLib.Installations.Models;
using DevIn.Extensions.DotNet.Installations.Models;
using DevIn.Extensions.Config.CompilerServices;
using DevIn.Extensions.Config.Decorations;
// using DevIn.Extensions.Git.Installations.Models;
using DevIn.TextEditor.RazorLib.CompilerServices;

namespace DevIn.Extensions.Config.Installations.Models;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDevInConfigServices(
        this IServiceCollection services,
        DevInHostingInformation hostingInformation,
        Func<DevInIdeConfig, DevInIdeConfig>? configure = null)
    {
        return services
            .AddDevInExtensionsDotNetServices(hostingInformation, configure)
            // .AddDevInExtensionsGitServices(hostingInformation, configure)
            .AddScoped<ICompilerServiceRegistry, ConfigCompilerServiceRegistry>()
            .AddScoped<IDecorationMapperRegistry, DecorationMapperRegistry>();
    }
}