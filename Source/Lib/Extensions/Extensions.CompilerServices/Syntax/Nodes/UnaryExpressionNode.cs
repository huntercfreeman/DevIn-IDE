using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class UnaryExpressionNode : IExpressionNode
{
	public UnaryExpressionNode(
		IExpressionNode expression,
		UnaryOperatorNode unaryOperatorNode)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.UnaryExpressionNode++;
		#endif
	
		Expression = expression;
		UnaryOperatorNode = unaryOperatorNode;
	}

	public IExpressionNode Expression { get; }
	public UnaryOperatorNode UnaryOperatorNode { get; }
	public TypeReference ResultTypeReference => UnaryOperatorNode.ResultTypeReference;

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.UnaryExpressionNode;

	#if DEBUG	
	~UnaryExpressionNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.UnaryExpressionNode--;
	}
	#endif
}