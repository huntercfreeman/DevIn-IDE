using DevIn.Common.RazorLib.Menus.Models;
using DevIn.Common.RazorLib.Namespaces.Models;
using DevIn.Common.RazorLib.Notifications.Models;
using DevIn.Ide.RazorLib.Terminals.Models;
using DevIn.Ide.RazorLib.BackgroundTasks.Models;
using DevIn.Extensions.DotNet.CSharpProjects.Models;
using DevIn.Extensions.DotNet.DotNetSolutions.Models;
using DevIn.Extensions.DotNet.Namespaces.Models;

namespace DevIn.Extensions.DotNet.Menus.Models;

public interface IDotNetMenuOptionsFactory
{
	public MenuOptionRecord RemoveCSharpProjectReferenceFromSolution(
		TreeViewSolution solutionNode,
		TreeViewNamespacePath projectNode,
		ITerminal terminal,
		INotificationService notificationService,
		Func<Task> onAfterCompletion);

	public MenuOptionRecord AddProjectToProjectReference(
		TreeViewNamespacePath projectReceivingReference,
		ITerminal terminal,
		INotificationService notificationService,
		IdeBackgroundTaskApi ideBackgroundTaskApi,
		Func<Task> onAfterCompletion);

	public MenuOptionRecord RemoveProjectToProjectReference(
		TreeViewCSharpProjectToProjectReference treeViewCSharpProjectToProjectReference,
		ITerminal terminal,
		INotificationService notificationService,
		Func<Task> onAfterCompletion);

	public MenuOptionRecord MoveProjectToSolutionFolder(
		TreeViewSolution treeViewSolution,
		TreeViewNamespacePath treeViewProjectToMove,
		ITerminal terminal,
		INotificationService notificationService,
		Func<Task> onAfterCompletion);

	public MenuOptionRecord RemoveNuGetPackageReferenceFromProject(
		NamespacePath modifyProjectNamespacePath,
		TreeViewCSharpProjectNugetPackageReference treeViewCSharpProjectNugetPackageReference,
		ITerminal terminal,
		INotificationService notificationService,
		Func<Task> onAfterCompletion);
}
