using DevIn.TextEditor.RazorLib.Decorations.Models;

namespace DevIn.Ide.RazorLib.Terminals.Models;

public class TerminalDecorationMapper : IDecorationMapper
{
    public string Map(byte decorationByte)
    {
        var decoration = (TerminalDecorationKind)decorationByte;

        return decoration switch
        {
            TerminalDecorationKind.None => string.Empty,
            TerminalDecorationKind.Comment => "di_te_comment",
            TerminalDecorationKind.Keyword => "di_te_keyword",
            TerminalDecorationKind.StringLiteral => "di_te_string-literal",
            TerminalDecorationKind.TargetFilePath => "di_te_type",
            TerminalDecorationKind.Error => "di_tree-view-exception",
            TerminalDecorationKind.Warning => "di_tree-view-warning",
            _ => string.Empty,
        };
    }
}
