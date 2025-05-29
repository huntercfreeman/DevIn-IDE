using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Enums;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class ConstructorDefinitionNode : ICodeBlockOwner, IFunctionDefinitionNode
{
	public ConstructorDefinitionNode(
		TypeReference returnTypeReference,
		SyntaxToken functionIdentifier,
		GenericParameterListing genericParameterListing,
		FunctionArgumentListing functionArgumentListing,
		CodeBlock codeBlock)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.ConstructorDefinitionNode++;
		#endif
	
		ReturnTypeReference = returnTypeReference;
		FunctionIdentifier = functionIdentifier;
		GenericParameterListing = genericParameterListing;
		FunctionArgumentListing = functionArgumentListing;
		CodeBlock = codeBlock;
	}

	public TypeReference ReturnTypeReference { get; }
	public SyntaxToken FunctionIdentifier { get; }
	public GenericParameterListing GenericParameterListing { get; }
	public FunctionArgumentListing FunctionArgumentListing { get; set; }

	// ICodeBlockOwner properties.
	public ScopeDirectionKind ScopeDirectionKind => ScopeDirectionKind.Down;
	public TextEditorTextSpan OpenCodeBlockTextSpan { get; set; }
	public CodeBlock CodeBlock { get; set; }
	public TextEditorTextSpan CloseCodeBlockTextSpan { get; set; }
	public int ScopeIndexKey { get; set; } = -1;

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.ConstructorDefinitionNode;
	
	TypeReference IExpressionNode.ResultTypeReference => TypeFacts.Pseudo.ToTypeReference();
	
	#region ICodeBlockOwner_Methods
	public TypeReference GetReturnTypeReference()
	{
		return ReturnTypeReference;
	}
	#endregion

	#if DEBUG	
	~ConstructorDefinitionNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.ConstructorDefinitionNode--;
	}
	#endif
}
