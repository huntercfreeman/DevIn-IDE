using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.CompilerServices.Json.SyntaxEnums;

namespace DevIn.CompilerServices.Json.SyntaxObjects;

public class JsonPropertyKeySyntax : IJsonSyntax
{
    public JsonPropertyKeySyntax(
        TextEditorTextSpan textEditorTextSpan,
		IReadOnlyList<IJsonSyntax> childJsonSyntaxes)
    {
        ChildJsonSyntaxes = childJsonSyntaxes;
        TextEditorTextSpan = textEditorTextSpan;
    }

    public TextEditorTextSpan TextEditorTextSpan { get; }
    public IReadOnlyList<IJsonSyntax> ChildJsonSyntaxes { get; }

    public JsonSyntaxKind JsonSyntaxKind => JsonSyntaxKind.PropertyKey;
}