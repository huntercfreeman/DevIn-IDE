using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.CompilerServices.Json.SyntaxEnums;

namespace DevIn.CompilerServices.Json.SyntaxObjects;

public class JsonObjectSyntax : IJsonSyntax
{
    public JsonObjectSyntax(
        TextEditorTextSpan textEditorTextSpan,
        IReadOnlyList<JsonPropertySyntax> jsonPropertySyntaxes)
    {
        TextEditorTextSpan = textEditorTextSpan;

        // To avoid re-evaluating the Select() for casting as (IJsonSyntax)
        // every time the ChildJsonSyntaxes getter is accessed
        // this is being done here initially on construction once.
        JsonPropertySyntaxes = jsonPropertySyntaxes
            .Select(x => (IJsonSyntax)x)
            .ToList();
    }

    public TextEditorTextSpan TextEditorTextSpan { get; }
    public IReadOnlyList<IJsonSyntax> JsonPropertySyntaxes { get; }
    public IReadOnlyList<IJsonSyntax> ChildJsonSyntaxes => JsonPropertySyntaxes;

    public JsonSyntaxKind JsonSyntaxKind => JsonSyntaxKind.Object;
}