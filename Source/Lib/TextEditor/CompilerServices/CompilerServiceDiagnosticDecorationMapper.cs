using DevIn.TextEditor.RazorLib.Decorations.Models;

namespace DevIn.TextEditor.RazorLib.CompilerServices;

public class CompilerServiceDiagnosticDecorationMapper : IDecorationMapper
{
    public string Map(byte decorationByte)
    {
        var decoration = (CompilerServiceDiagnosticDecorationKind)decorationByte;

        return decoration switch
        {
            CompilerServiceDiagnosticDecorationKind.None => string.Empty,
            CompilerServiceDiagnosticDecorationKind.DiagnosticError => "di_te_semantic-diagnostic-error",
            CompilerServiceDiagnosticDecorationKind.DiagnosticHint => "di_te_semantic-diagnostic-hint",
            CompilerServiceDiagnosticDecorationKind.DiagnosticSuggestion => "di_te_semantic-diagnostic-suggestion",
            CompilerServiceDiagnosticDecorationKind.DiagnosticWarning => "di_te_semantic-diagnostic-warning",
            CompilerServiceDiagnosticDecorationKind.DiagnosticOther => "di_te_semantic-diagnostic-other",
            _ => string.Empty,
        };
    }
}