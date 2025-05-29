using DevIn.TextEditor.RazorLib.Installations.Models;

namespace DevIn.Ide.RazorLib.Installations.Models;

/// <remarks>
/// This class is an exception to the naming convention, "don't use the word 'DevIn' in class names".
/// 
/// Reason for this exception: when one first starts interacting with this project,
/// 	this type might be one of the first types they interact with. So, the redundancy of namespace
/// 	and type containing 'DevIn' feels reasonable here.
/// </remarks>
public record DevInIdeConfig
{
    /// <summary>Default value is <see cref="true"/>. If one wishes to configure DevIn.TextEditor themselves, then set this to false, and invoke <see cref="TextEditor.RazorLib.Installations.Models.ServiceCollectionExtensions.AddDevInTextEditor(Microsoft.Extensions.DependencyInjection.IServiceCollection, Func{DevInTextEditorConfig, DevInTextEditorConfig}?)"/> prior to invoking DevIn.TextEditor's</summary>
    public bool AddDevInTextEditor { get; init; } = true;
}