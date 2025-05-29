using Microsoft.AspNetCore.Components;
using DevIn.Common.RazorLib.Options.Models;

namespace DevIn.Extensions.DotNet.CSharpProjects.Displays;

public partial class TreeViewCSharpProjectDependenciesDisplay : ComponentBase
{
    [Inject]
    private IAppOptionsService AppOptionsService { get; set; } = null!;
}