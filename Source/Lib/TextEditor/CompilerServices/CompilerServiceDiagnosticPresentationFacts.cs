using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib.Decorations.Models;

namespace DevIn.TextEditor.RazorLib.CompilerServices;

public static class CompilerServiceDiagnosticPresentationFacts
{
	public const string CssClassString = "di_te_compiler-service-diagnostic-presentation";

	public static readonly Key<TextEditorPresentationModel> PresentationKey = Key<TextEditorPresentationModel>.NewKey();

	public static readonly TextEditorPresentationModel EmptyPresentationModel = new(
		PresentationKey,
		0,
		CssClassString,
		new CompilerServiceDiagnosticDecorationMapper());
}
