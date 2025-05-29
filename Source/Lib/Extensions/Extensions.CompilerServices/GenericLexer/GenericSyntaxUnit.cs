using DevIn.Extensions.CompilerServices.GenericLexer.SyntaxObjects;
using DevIn.TextEditor.RazorLib.CompilerServices;

namespace DevIn.Extensions.CompilerServices.GenericLexer;

public class GenericSyntaxUnit
{
	public GenericSyntaxUnit(
		GenericDocumentSyntax genericDocumentSyntax,
		List<TextEditorDiagnostic> diagnosticList)
	{
		GenericDocumentSyntax = genericDocumentSyntax;
		DiagnosticList = diagnosticList;
	}

	public GenericDocumentSyntax GenericDocumentSyntax { get; }
	public IReadOnlyList<TextEditorDiagnostic> DiagnosticList { get; }
}