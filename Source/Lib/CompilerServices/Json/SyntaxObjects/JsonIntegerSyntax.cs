using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.CompilerServices.Json.SyntaxEnums;

namespace DevIn.CompilerServices.Json.SyntaxObjects;

public class JsonIntegerSyntax : IJsonSyntax
{
    public JsonIntegerSyntax(
        TextEditorTextSpan textEditorTextSpan)
    {
        TextEditorTextSpan = textEditorTextSpan;
    }

    public TextEditorTextSpan TextEditorTextSpan { get; }
    public IReadOnlyList<IJsonSyntax> ChildJsonSyntaxes => Array.Empty<IJsonSyntax>();

    public JsonSyntaxKind JsonSyntaxKind => JsonSyntaxKind.Integer;
}