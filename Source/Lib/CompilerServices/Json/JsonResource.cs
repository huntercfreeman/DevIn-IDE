using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.CompilerServices.Json;

public class JsonResource : CompilerServiceResource
{
    public JsonResource(ResourceUri resourceUri, JsonCompilerService jsonCompilerService)
        : base(resourceUri, jsonCompilerService)
    {
    }
}