using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class ExplicitCastNode : IExpressionNode
{
	public ExplicitCastNode(
		SyntaxToken openParenthesisToken,
		TypeReference resultTypeReference,
		SyntaxToken closeParenthesisToken)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.ExplicitCastNode++;
		#endif
	
		OpenParenthesisToken = openParenthesisToken;
		ResultTypeReference = resultTypeReference;
		CloseParenthesisToken = closeParenthesisToken;
	}

	public ExplicitCastNode(SyntaxToken openParenthesisToken, TypeReference resultTypeReference)
		: this(openParenthesisToken, resultTypeReference, default)
	{
	}

	public SyntaxToken OpenParenthesisToken { get; }
	public TypeReference ResultTypeReference { get; }
	public SyntaxToken CloseParenthesisToken { get; set; }

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.ExplicitCastNode;

	#if DEBUG	
	~ExplicitCastNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.ExplicitCastNode--;
	}
	#endif
}
