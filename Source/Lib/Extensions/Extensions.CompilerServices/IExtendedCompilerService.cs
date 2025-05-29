using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.Extensions.CompilerServices.Syntax;

namespace DevIn.Extensions.CompilerServices;

public interface IExtendedCompilerService : ICompilerService
{
	public ISyntaxNode? GetSyntaxNode(int positionIndex, ResourceUri resourceUri, ICompilerServiceResource? compilerServiceResource);
	public ISyntaxNode? GetDefinitionNode(TextEditorTextSpan textSpan, ICompilerServiceResource compilerServiceResource, Symbol? symbol = null);
    public TextEditorTextSpan? GetDefinitionTextSpan(TextEditorTextSpan textSpan, ICompilerServiceResource compilerServiceResource);
    public Scope GetScopeByPositionIndex(ResourceUri resourceUri, int positionIndex);    
}
