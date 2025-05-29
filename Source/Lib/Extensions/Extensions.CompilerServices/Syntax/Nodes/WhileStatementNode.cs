using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Enums;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class WhileStatementNode : ICodeBlockOwner
{
	public WhileStatementNode(
		SyntaxToken keywordToken,
		SyntaxToken openParenthesisToken,
		IExpressionNode expressionNode,
		SyntaxToken closeParenthesisToken,
		CodeBlock codeBlock)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.WhileStatementNode++;
		#endif
	
		KeywordToken = keywordToken;
		OpenParenthesisToken = openParenthesisToken;
		ExpressionNode = expressionNode;
		CloseParenthesisToken = closeParenthesisToken;
		CodeBlock = codeBlock;
	}

	public SyntaxToken KeywordToken { get; }
	public SyntaxToken OpenParenthesisToken { get; }
	public IExpressionNode ExpressionNode { get; set; }
	public SyntaxToken CloseParenthesisToken { get; }

	// ICodeBlockOwner properties.
	public ScopeDirectionKind ScopeDirectionKind => ScopeDirectionKind.Down;
	public TextEditorTextSpan OpenCodeBlockTextSpan { get; set; }
	public CodeBlock CodeBlock { get; set; }
	public TextEditorTextSpan CloseCodeBlockTextSpan { get; set; }
	public int ScopeIndexKey { get; set; } = -1;

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.WhileStatementNode;

	#region ICodeBlockOwner_Methods
	public TypeReference GetReturnTypeReference()
	{
		return TypeFacts.NotApplicable.ToTypeReference();
	}
	#endregion

	#if DEBUG	
	~WhileStatementNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.WhileStatementNode--;
	}
	#endif
}
