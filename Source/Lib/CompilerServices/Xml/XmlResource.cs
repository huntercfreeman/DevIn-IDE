using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.CompilerServices.Xml;

public sealed class XmlResource : CompilerServiceResource
{
    public XmlResource(ResourceUri resourceUri, XmlCompilerService xmlCompilerService)
        : base(resourceUri, xmlCompilerService)
    {
    }
}