using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.CompilerServices.Css.SyntaxObjects;

namespace DevIn.CompilerServices.Css;

public class CssSyntaxUnit
{
    public CssSyntaxUnit(
        CssDocumentSyntax cssDocumentSyntax,
        List<TextEditorDiagnostic> diagnosticList)
    {
        CssDocumentSyntax = cssDocumentSyntax;
        DiagnosticList = diagnosticList;
    }

    public CssDocumentSyntax CssDocumentSyntax { get; }
    public List<TextEditorDiagnostic> DiagnosticList { get; }
}