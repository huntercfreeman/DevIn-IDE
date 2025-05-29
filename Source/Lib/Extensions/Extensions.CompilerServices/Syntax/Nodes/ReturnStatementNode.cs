using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class ReturnStatementNode : IExpressionNode
{
	public ReturnStatementNode(SyntaxToken keywordToken, IExpressionNode expressionNode)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.ReturnStatementNode++;
		#endif
	
		KeywordToken = keywordToken;
		ExpressionNode = expressionNode;
	}

	public SyntaxToken KeywordToken { get; }
	public IExpressionNode ExpressionNode { get; set; }
	public TypeReference ResultTypeReference => ExpressionNode.ResultTypeReference;

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.ReturnStatementNode;

	#if DEBUG	
	~ReturnStatementNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.ReturnStatementNode--;
	}
	#endif
}