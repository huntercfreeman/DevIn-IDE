using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.CompilerServices.Json.SyntaxObjects;

namespace DevIn.CompilerServices.Json;

public class JsonSyntaxUnit
{
    public JsonSyntaxUnit(
        JsonDocumentSyntax jsonDocumentSyntax,
        List<TextEditorDiagnostic> diagnosticList)
    {
        JsonDocumentSyntax = jsonDocumentSyntax;
        DiagnosticList = diagnosticList;
    }

    public JsonDocumentSyntax JsonDocumentSyntax { get; }
    public List<TextEditorDiagnostic> DiagnosticList { get; }
}