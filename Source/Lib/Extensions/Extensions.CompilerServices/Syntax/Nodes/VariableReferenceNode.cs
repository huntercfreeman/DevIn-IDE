using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class VariableReferenceNode : IExpressionNode
{
	public VariableReferenceNode(
		SyntaxToken variableIdentifierToken,
		VariableDeclarationNode variableDeclarationNode)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.VariableReferenceNode++;
		#endif
	
		VariableIdentifierToken = variableIdentifierToken;
		VariableDeclarationNode = variableDeclarationNode;
	}
	
	public VariableReferenceNode(VariableReference variableReference)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.VariableReferenceNode++;
		#endif
	
		VariableIdentifierToken = variableReference.VariableIdentifierToken;
		VariableDeclarationNode = variableReference.VariableDeclarationNode;
		IsFabricated = variableReference.IsFabricated;
	}

	private bool _isFabricated;
	
	public bool IsBeingUsed { get; set; } = false;

	public SyntaxToken VariableIdentifierToken { get; private set; }
	/// <summary>
	/// The <see cref="VariableDeclarationNode"/> is null when the variable is undeclared
	/// </summary>
	public VariableDeclarationNode VariableDeclarationNode { get; private set; }
	public TypeReference ResultTypeReference
	{
		get
		{
			if (VariableDeclarationNode is null)
				return TypeFacts.Empty.ToTypeReference();
			
			return VariableDeclarationNode.TypeReference;
		}
	}

	public bool IsFabricated
	{
		get
		{
			return _isFabricated;
		}
		init
		{
			_isFabricated = value;
		}
	}
	public SyntaxKind SyntaxKind => SyntaxKind.VariableReferenceNode;
	
	public void SetSharedInstance(
		SyntaxToken variableIdentifierToken,
		VariableDeclarationNode variableDeclarationNode)
	{
		IsBeingUsed = true;
	
		VariableIdentifierToken = variableIdentifierToken;
		VariableDeclarationNode = variableDeclarationNode;
		_isFabricated = false;
	}

	#if DEBUG	
	~VariableReferenceNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.VariableReferenceNode--;
	}
	#endif
}
