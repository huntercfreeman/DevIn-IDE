using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.CompilerServices.Json.SyntaxEnums;

namespace DevIn.CompilerServices.Json.SyntaxObjects;

public class JsonPropertyValueSyntax : IJsonSyntax
{
    public JsonPropertyValueSyntax(
        TextEditorTextSpan textEditorTextSpan,
        IJsonSyntax underlyingJsonSyntax)
    {
        UnderlyingJsonSyntax = underlyingJsonSyntax;
        TextEditorTextSpan = textEditorTextSpan;
    }

    public static JsonPropertyValueSyntax GetInvalidJsonPropertyValueSyntax()
    {
        return new JsonPropertyValueSyntax(
            new TextEditorTextSpan(
                0,
                0,
                default,
                ResourceUri.Empty,
                string.Empty),
            null);
    }

    public IJsonSyntax UnderlyingJsonSyntax { get; }
    public TextEditorTextSpan TextEditorTextSpan { get; }
    public IReadOnlyList<IJsonSyntax> ChildJsonSyntaxes => new List<IJsonSyntax>
    {
        UnderlyingJsonSyntax
    };

    public JsonSyntaxKind JsonSyntaxKind => JsonSyntaxKind.PropertyValue;
}