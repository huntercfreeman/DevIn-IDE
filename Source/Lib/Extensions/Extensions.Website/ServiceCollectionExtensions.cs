using Microsoft.Extensions.DependencyInjection;
using DevIn.Common.RazorLib.Installations.Models;
using DevIn.Ide.RazorLib.Installations.Models;
using DevIn.Extensions.Config.Installations.Models;

namespace DevIn.Website.RazorLib;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDevInWebsiteServices(
        this IServiceCollection services,
        DevInHostingInformation hostingInformation)
    {
        services.AddDevInIdeRazorLibServices(hostingInformation);
        services.AddDevInConfigServices(hostingInformation);
        
        return services;
    }
}
