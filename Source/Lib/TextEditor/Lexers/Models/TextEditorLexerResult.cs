using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.RenderStates.Models;

namespace DevIn.TextEditor.RazorLib.Lexers.Models;

public interface TextEditorLexerResult
{
    public IReadOnlyList<TextEditorTextSpan> TextSpanList { get; }
    public string ResourceUri { get; }
    public Key<RenderState> ModelRenderStateKey { get; }
}