using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.CompilerServices.Xml.Html.InjectedLanguage;

namespace DevIn.CompilerServices.Xml.Html.ExtensionMethods;

public static class StringWalkerExtensions
{
    public static bool AtInjectedLanguageCodeBlockTag(
        this StringWalker stringWalker,
        InjectedLanguageDefinition injectedLanguageDefinition)
    {
        var isMatch = stringWalker.PeekForSubstring(injectedLanguageDefinition.TransitionSubstring);
        var isEscaped = stringWalker.PeekForSubstring(injectedLanguageDefinition.TransitionSubstringEscaped);

        return isMatch && !isEscaped;
    }
}