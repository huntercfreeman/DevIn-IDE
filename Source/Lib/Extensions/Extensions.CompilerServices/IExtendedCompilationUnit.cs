using DevIn.TextEditor.RazorLib.CompilerServices;
using DevIn.Extensions.CompilerServices.Syntax;
using DevIn.Extensions.CompilerServices.Syntax.Nodes;

namespace DevIn.Extensions.CompilerServices;

public interface IExtendedCompilationUnit : ICompilationUnit
{
	public IReadOnlyList<Symbol> SymbolList { get; }
	public Dictionary<ScopeKeyAndIdentifierText, TypeDefinitionNode> ScopeTypeDefinitionMap { get; }
	public Dictionary<ScopeKeyAndIdentifierText, FunctionDefinitionNode> ScopeFunctionDefinitionMap { get; }
}
