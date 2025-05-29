using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class AmbiguousIdentifierExpressionNode : IGenericParameterNode
{
	public AmbiguousIdentifierExpressionNode(
		SyntaxToken token,
		GenericParameterListing genericParameterListing,
		TypeReference resultTypeReference)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.AmbiguousIdentifierExpressionNode++;
		#endif
	
		Token = token;
		GenericParameterListing = genericParameterListing;
		ResultTypeReference = resultTypeReference;
	}
	
	public SyntaxToken Token { get; set; }
	public GenericParameterListing GenericParameterListing { get; set; }
	public TypeReference ResultTypeReference { get; set; }
	public bool FollowsMemberAccessToken { get; set; }
	public bool HasQuestionMark { get; set; }

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.AmbiguousIdentifierExpressionNode;
	
	public void SetSharedInstance(
		SyntaxToken token,
		GenericParameterListing genericParameterListing,
		TypeReference resultTypeReference,
		bool followsMemberAccessToken)
	{
		Token = token;
		GenericParameterListing = genericParameterListing;
		ResultTypeReference = resultTypeReference;
		FollowsMemberAccessToken = followsMemberAccessToken;
		HasQuestionMark = false;
	}
	
	public bool IsParsingGenericParameters { get; set; }

	#if DEBUG	
	~AmbiguousIdentifierExpressionNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.AmbiguousIdentifierExpressionNode--;
	}
	#endif
}

