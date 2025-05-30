using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class BinaryExpressionNode : IExpressionNode
{
	public BinaryExpressionNode(
		IExpressionNode leftExpressionNode,
		TypeReference leftOperandTypeReference,
		SyntaxToken operatorToken,
		TypeReference rightOperandTypeReference,
		TypeReference resultTypeReference,
		IExpressionNode rightExpressionNode)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.BinaryExpressionNode++;
		#endif
	
		LeftExpressionNode = leftExpressionNode;
		LeftOperandTypeReference = leftOperandTypeReference;
		OperatorToken = operatorToken;
		RightOperandTypeReference = rightOperandTypeReference;
		ResultTypeReference = resultTypeReference;
		RightExpressionNode = rightExpressionNode;
	}

	public BinaryExpressionNode(
			IExpressionNode leftExpressionNode,
			TypeReference leftOperandTypeReference,
			SyntaxToken operatorToken,
			TypeReference rightOperandTypeReference,
			TypeReference resultTypeReference)
		: this(
			leftExpressionNode,
			leftOperandTypeReference,
			operatorToken,
			rightOperandTypeReference,
			resultTypeReference,
			EmptyExpressionNode.Empty)
	{
	}

	public IExpressionNode LeftExpressionNode { get; }
	public TypeReference LeftOperandTypeReference { get; }
	public SyntaxToken OperatorToken { get; }
	public TypeReference RightOperandTypeReference { get; }
	public TypeReference ResultTypeReference { get; }
	public IExpressionNode RightExpressionNode { get; set; }

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.BinaryExpressionNode;

	#if DEBUG	
	~BinaryExpressionNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.BinaryExpressionNode--;
	}
	#endif
}