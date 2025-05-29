using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.Installations.Models;
using DevIn.Ide.RazorLib.AppDatas.Models;

namespace DevIn.Ide.RazorLib.Settings.Displays;

public partial class IdeSettingsDisplay : ComponentBase
{
	[Inject]
	private IEnvironmentProvider EnvironmentProvider { get; set; } = null!;
	[Inject]
	private IAppDataService AppDataService { get; set; } = null!;
	
	private void WriteDevInDebugSomethingToConsole()
	{
		Console.WriteLine(DevInDebugSomething.CreateText());
		/*
		#if DEBUG
		Console.WriteLine(DevInDebugSomething.CreateText());
		#else
		Console.WriteLine($"Must run in debug mode to see {nameof(WriteDevInDebugSomethingToConsole)}");
		#endif
		*/
	}
}