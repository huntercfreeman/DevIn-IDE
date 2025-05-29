namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class InheritanceStatementNode : ISyntaxNode
{
	public InheritanceStatementNode(TypeClauseNode parentTypeClauseNode)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.InheritanceStatementNode++;
		#endif
	
		ParentTypeClauseNode = parentTypeClauseNode;
	}

	public TypeClauseNode ParentTypeClauseNode { get; }

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.InheritanceStatementNode;

	#if DEBUG	
	~InheritanceStatementNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.InheritanceStatementNode--;
	}
	#endif
}