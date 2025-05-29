using DevIn.Common.RazorLib.FileSystems.Models;
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.CompilerServices.DotNetSolution.Models;
using DevIn.Ide.RazorLib.CommandLines.Models;
using DevIn.Ide.RazorLib.Terminals.Models;
using DevIn.Extensions.DotNet.Websites.ProjectTemplates.Models;

namespace DevIn.Extensions.DotNet.CSharpProjects.Models;

public record CSharpProjectFormViewModelImmutable(
	DotNetSolutionModel DotNetSolutionModel,
	IEnvironmentProvider EnvironmentProvider,
	bool IsReadingProjectTemplates,
	string ProjectTemplateShortNameValue,
	string CSharpProjectNameValue,
	string OptionalParametersValue,
	string ParentDirectoryNameValue,
	List<ProjectTemplate> ProjectTemplateList,
	CSharpProjectFormPanelKind ActivePanelKind,
	string SearchInput,
	ProjectTemplate? SelectedProjectTemplate,
	bool IsValid,
	string ProjectTemplateShortNameDisplay,
	string CSharpProjectNameDisplay,
	string OptionalParametersDisplay,
	string ParentDirectoryNameDisplay,
	FormattedCommand FormattedNewCSharpProjectCommand,
	FormattedCommand FormattedAddExistingProjectToSolutionCommand,
	Key<TerminalCommandRequest> NewCSharpProjectTerminalCommandRequestKey,
	Key<TerminalCommandRequest> AddCSharpProjectToSolutionTerminalCommandRequestKey,
	Key<TerminalCommandRequest> LoadProjectTemplatesTerminalCommandRequestKey,
	CancellationTokenSource NewCSharpProjectCancellationTokenSource);