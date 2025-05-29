using DevIn.Common.RazorLib.Keys.Models;
using DevIn.TextEditor.RazorLib.Decorations.Models;

namespace DevIn.TextEditor.RazorLib.TextEditors.Models.Internals;

public static class FindOverlayPresentationFacts
{
    public const string CssClassString = "di_te_find-overlay-presentation";

    public static readonly Key<TextEditorPresentationModel> PresentationKey = Key<TextEditorPresentationModel>.NewKey();

    public static readonly TextEditorPresentationModel EmptyPresentationModel = new(
        PresentationKey,
        0,
        CssClassString,
        new FindOverlayDecorationMapper());
}
