using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.FileSystems.Models;

namespace DevIn.Ide.RazorLib.InputFiles.Displays;

public partial class InputFileAddressHierarchyEntry : ComponentBase
{
    [Parameter, EditorRequired]
    public AbsolutePath AbsolutePath { get; set; }
}