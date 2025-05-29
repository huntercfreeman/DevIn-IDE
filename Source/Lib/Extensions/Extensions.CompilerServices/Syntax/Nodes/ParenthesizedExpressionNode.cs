using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class ParenthesizedExpressionNode : IExpressionNode
{
	public ParenthesizedExpressionNode(
		SyntaxToken openParenthesisToken,
		IExpressionNode innerExpression,
		SyntaxToken closeParenthesisToken)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.ParenthesizedExpressionNode++;
		#endif
	
		OpenParenthesisToken = openParenthesisToken;
		InnerExpression = innerExpression;
		CloseParenthesisToken = closeParenthesisToken;
	}

	public ParenthesizedExpressionNode(SyntaxToken openParenthesisToken, TypeReference typeReference)
		: this(openParenthesisToken, EmptyExpressionNode.Empty, default)
	{
	}

	public SyntaxToken OpenParenthesisToken { get; }
	public IExpressionNode InnerExpression { get; set; }
	public SyntaxToken CloseParenthesisToken { get; set; }
	public TypeReference ResultTypeReference => InnerExpression.ResultTypeReference;

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.ParenthesizedExpressionNode;

	#if DEBUG	
	~ParenthesizedExpressionNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.ParenthesizedExpressionNode--;
	}
	#endif
}
