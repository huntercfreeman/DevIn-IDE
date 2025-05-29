namespace DevIn.Extensions.DotNet.BackgroundTasks.Models;

public enum DotNetBackgroundTaskApiWorkKind
{
	None,
    SolutionExplorer_TreeView_MultiSelect_DeleteFiles,
    DevInExtensionsDotNetInitializerOnInit,
    DevInExtensionsDotNetInitializerOnAfterRender,
    SubmitNuGetQuery,
    RunTestByFullyQualifiedName,
    SetDotNetSolution,
	SetDotNetSolutionTreeView,
	Website_AddExistingProjectToSolution,
}
