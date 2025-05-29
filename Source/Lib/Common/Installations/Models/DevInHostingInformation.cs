using DevIn.Common.RazorLib.BackgroundTasks.Models;

namespace DevIn.Common.RazorLib.Installations.Models;

/// <summary>
/// One use case for <see cref="DevInHostingInformation"/> would be service registration.<br/><br/>
/// If one uses <see cref="DevInHostingKind.ServerSide"/>, then 
/// services.AddHostedService&lt;TService&gt;(...); will be invoked.<br/><br/>
/// Whereas, if one uses <see cref="DevInHostingKind.Wasm"/> then 
/// services.AddSingleton&lt;TService&gt;(...); will be used.
/// Then after the initial render, a Task will be 'fire and forget' invoked to start the service.
/// </summary>
/// <remarks>
/// This class is an exception to the naming convention, "don't use the word 'DevIn' in class names".
/// 
/// Reason for this exception: when one first starts interacting with this project,
/// 	this type might be one of the first types they interact with. So, the redundancy of namespace
/// 	and type containing 'DevIn' feels reasonable here.
/// </remarks>
public record DevInHostingInformation
{
    public DevInHostingInformation(
        DevInHostingKind devInHostingKind,
        DevInPurposeKind devInPurposeKind,
        BackgroundTaskService backgroundTaskService)
    {
        DevInHostingKind = devInHostingKind;
        DevInPurposeKind = devInPurposeKind;
        BackgroundTaskService = backgroundTaskService;
    }

    public DevInHostingKind DevInHostingKind { get; init; }
    public DevInPurposeKind DevInPurposeKind { get; init; }
    public BackgroundTaskService BackgroundTaskService { get; init; }
    /// <summary>
    /// If the main window hasn't been initialized yet, 0 is returned.
    /// Whether 0 returns at other points is uncertain.
    /// 
    /// This also returns 0 if the host isn't Photino (i.e.: ServerSide Blazor or Wasm Blazor)
    /// </summary>
    public Func<uint> GetMainWindowScreenDpiFunc { get; set; } = () => 0;
}