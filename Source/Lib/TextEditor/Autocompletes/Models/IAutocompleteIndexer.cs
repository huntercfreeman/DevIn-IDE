using DevIn.TextEditor.RazorLib.TextEditors.Models;
using System.Collections.Concurrent;

namespace DevIn.TextEditor.RazorLib.Autocompletes.Models;

public interface IAutocompleteIndexer : IDisposable
{
    public ConcurrentBag<string> IndexedStringsList { get; }

    public Task IndexTextEditorAsync(TextEditorModel textEditorModel);
    public Task IndexWordAsync(string word);
}