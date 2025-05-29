using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib.Decorations.Models;

namespace DevIn.TextEditor.RazorLib.TextEditors.Models.Internals;

public static class TextEditorDevToolsPresentationFacts
{
    public const string CssClassString = "di_te_dev-tools-presentation";

    public static readonly Key<TextEditorPresentationModel> PresentationKey = Key<TextEditorPresentationModel>.NewKey();

    public static readonly TextEditorPresentationModel EmptyPresentationModel = new(
        PresentationKey,
        0,
        CssClassString,
        new TextEditorDevToolsDecorationMapper());
}

