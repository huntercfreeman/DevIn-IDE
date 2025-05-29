using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.Installations.Models;
using DevIn.Ide.Wasm;
using DevIn.Website.RazorLib;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var hostingInformation = new DevInHostingInformation(
    DevInHostingKind.Wasm,
    DevInPurposeKind.Ide,
    new BackgroundTaskService());

builder.Services.AddDevInWebsiteServices(hostingInformation);

await builder.Build().RunAsync();
