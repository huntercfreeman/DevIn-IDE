using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.CompilerServices.Json.SyntaxEnums;

namespace DevIn.CompilerServices.Json;

public interface IJsonSyntax
{
    public JsonSyntaxKind JsonSyntaxKind { get; }
    public TextEditorTextSpan TextEditorTextSpan { get; }
    public IReadOnlyList<IJsonSyntax> ChildJsonSyntaxes { get; }
}