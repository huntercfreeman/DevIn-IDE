namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class UnaryOperatorNode : ISyntaxNode
{
	public UnaryOperatorNode(
		TypeReference operandTypeReference,
		SyntaxToken operatorToken,
		TypeReference resultTypeReference)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.UnaryOperatorNode++;
		#endif
	
		OperandTypeReference = operandTypeReference;
		OperatorToken = operatorToken;
		ResultTypeReference = resultTypeReference;
	}

	public TypeReference OperandTypeReference { get; }
	public SyntaxToken OperatorToken { get; }
	public TypeReference ResultTypeReference { get; }

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.UnaryOperatorNode;

	#if DEBUG	
	~UnaryOperatorNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.UnaryOperatorNode--;
	}
	#endif
}