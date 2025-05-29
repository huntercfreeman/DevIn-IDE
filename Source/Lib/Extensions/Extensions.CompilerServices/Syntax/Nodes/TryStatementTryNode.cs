using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Enums;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class TryStatementTryNode : ICodeBlockOwner
{
	public TryStatementTryNode(
		TryStatementNode? parent,
		SyntaxToken keywordToken,
		CodeBlock codeBlock)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.TryStatementTryNode++;
		#endif
	
		Parent = parent;
		KeywordToken = keywordToken;
		CodeBlock = codeBlock;
	}

	public SyntaxToken KeywordToken { get; }

	// ICodeBlockOwner properties.
	public ScopeDirectionKind ScopeDirectionKind => ScopeDirectionKind.Down;
	public TextEditorTextSpan OpenCodeBlockTextSpan { get; set; }
	public CodeBlock CodeBlock { get; set; }
	public TextEditorTextSpan CloseCodeBlockTextSpan { get; set; }
	public int ScopeIndexKey { get; set; } = -1;

	public ISyntaxNode? Parent { get; }

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.TryStatementTryNode;

	#region ICodeBlockOwner_Methods
	public TypeReference GetReturnTypeReference()
	{
		return TypeFacts.Empty.ToTypeReference();
	}
	#endregion

	#if DEBUG	
	~TryStatementTryNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.TryStatementTryNode--;
	}
	#endif
}
