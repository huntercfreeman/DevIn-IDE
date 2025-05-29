using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Enums;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class IfStatementNode : ICodeBlockOwner
{
	public IfStatementNode(
		SyntaxToken keywordToken,
		IExpressionNode expressionNode,
		CodeBlock codeBlock)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.IfStatementNode++;
		#endif
	
		KeywordToken = keywordToken;
		ExpressionNode = expressionNode;
		CodeBlock = codeBlock;
	}

	public SyntaxToken KeywordToken { get; }
	public IExpressionNode ExpressionNode { get; set; }

	// ICodeBlockOwner properties.
	public ScopeDirectionKind ScopeDirectionKind => ScopeDirectionKind.Down;
	public TextEditorTextSpan OpenCodeBlockTextSpan { get; set; }
	public CodeBlock CodeBlock { get; set; }
	public TextEditorTextSpan CloseCodeBlockTextSpan { get; set; }
	public int ScopeIndexKey { get; set; } = -1;

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.IfStatementNode;

	#region ICodeBlockOwner_Methods
	public TypeReference GetReturnTypeReference()
	{
		return TypeFacts.Empty.ToTypeReference();
	}
	#endregion

	#if DEBUG	
	~IfStatementNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.IfStatementNode--;
	}
	#endif
}