using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class FunctionInvocationNode : IInvocationNode, IGenericParameterNode
{
	public FunctionInvocationNode(
		SyntaxToken functionInvocationIdentifierToken,
		FunctionDefinitionNode? functionDefinitionNode,
		GenericParameterListing genericParameterListing,
		FunctionParameterListing functionParameterListing,
		TypeReference resultTypeReference)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.FunctionInvocationNode++;
		#endif
	
		FunctionInvocationIdentifierToken = functionInvocationIdentifierToken;
		FunctionDefinitionNode = functionDefinitionNode;
		GenericParameterListing = genericParameterListing;
		FunctionParameterListing = functionParameterListing;
		ResultTypeReference = resultTypeReference;
	}

	public SyntaxToken FunctionInvocationIdentifierToken { get; }
	public FunctionDefinitionNode? FunctionDefinitionNode { get; }
	public GenericParameterListing GenericParameterListing { get; set; }
	public FunctionParameterListing FunctionParameterListing { get; set; }
	public TypeReference ResultTypeReference { get; set; }

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.FunctionInvocationNode;
	
	public bool IsParsingFunctionParameters { get; set; }
	public bool IsParsingGenericParameters { get; set; }

	#if DEBUG	
	~FunctionInvocationNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.FunctionInvocationNode--;
	}
	#endif
}
