using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class LiteralExpressionNode : IExpressionNode
{
	public LiteralExpressionNode(SyntaxToken literalSyntaxToken, TypeReference typeReference)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.LiteralExpressionNode++;
		#endif
	
		LiteralSyntaxToken = literalSyntaxToken;
		ResultTypeReference = typeReference;
	}

	public SyntaxToken LiteralSyntaxToken { get; }
	public TypeReference ResultTypeReference { get; }

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.LiteralExpressionNode;

	#if DEBUG	
	~LiteralExpressionNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.LiteralExpressionNode--;
	}
	#endif
}
