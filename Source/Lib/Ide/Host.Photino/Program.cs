using System;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.Installations.Models;
using DevIn.Ide.RazorLib.Installations.Models;
using DevIn.Extensions.Config.Installations.Models;

namespace DevIn.Ide.Photino;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

        appBuilder.Services.AddLogging();

        var hostingInformation = new DevInHostingInformation(
            DevInHostingKind.Photino,
            DevInPurposeKind.Ide,
            new BackgroundTaskService());

        appBuilder.Services.AddDevInIdeRazorLibServices(hostingInformation);
        appBuilder.Services.AddDevInConfigServices(hostingInformation);

        appBuilder.RootComponents.Add<App>("app");

        var app = appBuilder.Build();

        // customize window
        app.MainWindow
			// Am doing development with a locally published version of the IDE
			// on Ubuntu. The text editor isn't fully optimized,
			// and the default Log for Photino is the console.
			// So, to help the integrated terminal I'm
			// setting verbosity to 0 (which turns off logging) for now (2024-05-14).
			.SetLogVerbosity(0)
            .SetIconFile("favicon.ico")
            .SetTitle("DevIn IDE")
            .SetDevToolsEnabled(true)
            .SetContextMenuEnabled(true)
            .SetUseOsDefaultSize(false)
            .SetSize(2470, 2000)
            .SetLeft(50)
            .SetTop(50);

        hostingInformation.GetMainWindowScreenDpiFunc = () =>
        {
            try
            {
                return app.MainWindow.ScreenDpi;
            }
            catch (Exception e)
            {
                // Eat this exception
                return 0;
            }
        };

        // Personal settings to have closing and reopening the IDE be exactly where I want while developing.
        {
            var specialFolderUserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		    if (specialFolderUserProfile == "C:\\Users\\hunte")
                app.MainWindow.SetLeft(1_355);
            else if (specialFolderUserProfile == "/home/hunter")
                app.MainWindow.SetLeft(1_200).SetTop(100).SetHeight(1900);
        }

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
        };

        app.Run();
    }
}
