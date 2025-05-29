using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class WithExpressionNode : IExpressionNode
{
	public WithExpressionNode(VariableReference variableReference)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.WithExpressionNode++;
		#endif
	
		VariableReference = variableReference;
		ResultTypeReference = variableReference.ResultTypeReference;
	}

	public VariableReference VariableReference { get; }
	public TypeReference ResultTypeReference { get; }

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.WithExpressionNode;

	#if DEBUG	
	~WithExpressionNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.WithExpressionNode--;
	}
	#endif
}
