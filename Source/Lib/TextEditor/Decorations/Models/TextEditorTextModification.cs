using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.TextEditor.RazorLib.Decorations.Models;

public record struct TextEditorTextModification(bool WasInsertion, TextEditorTextSpan TextEditorTextSpan);