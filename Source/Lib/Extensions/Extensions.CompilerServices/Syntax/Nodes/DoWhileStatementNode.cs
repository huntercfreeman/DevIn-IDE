using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Enums;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class DoWhileStatementNode : ICodeBlockOwner
{
	public DoWhileStatementNode(
		SyntaxToken doKeywordToken,
		SyntaxToken whileKeywordToken,
		SyntaxToken openParenthesisToken,
		IExpressionNode? expressionNode,
		SyntaxToken closeParenthesisToken)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.DoWhileStatementNode++;
		#endif
	
		DoKeywordToken = doKeywordToken;
		WhileKeywordToken = whileKeywordToken;
		OpenParenthesisToken = openParenthesisToken;
		ExpressionNode = expressionNode;
		CloseParenthesisToken = closeParenthesisToken;
	}

	public SyntaxToken DoKeywordToken { get; }
	public SyntaxToken WhileKeywordToken { get; set; }
	public SyntaxToken OpenParenthesisToken { get; set; }
	public IExpressionNode? ExpressionNode { get; set; }
	public SyntaxToken CloseParenthesisToken { get; set; }

	// ICodeBlockOwner properties.
	public ScopeDirectionKind ScopeDirectionKind => ScopeDirectionKind.Down;
	public TextEditorTextSpan OpenCodeBlockTextSpan { get; set; }
	public CodeBlock CodeBlock { get; set; }
	public TextEditorTextSpan CloseCodeBlockTextSpan { get; set; }
	public int ScopeIndexKey { get; set; } = -1;

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.DoWhileStatementNode;

	#region ICodeBlockOwner_Methods
	public TypeReference GetReturnTypeReference()
	{
		return TypeFacts.Empty.ToTypeReference();
	}
	#endregion

	#if DEBUG	
	~DoWhileStatementNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.DoWhileStatementNode--;
	}
	#endif
}
