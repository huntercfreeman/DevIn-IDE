using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Enums;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class GetterOrSetterNode : ICodeBlockOwner
{
	public GetterOrSetterNode()
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.GetterOrSetterNode++;
		#endif
	}

	// ICodeBlockOwner properties.
	public ScopeDirectionKind ScopeDirectionKind => ScopeDirectionKind.Down;
	public TextEditorTextSpan OpenCodeBlockTextSpan { get; set; }
	public CodeBlock CodeBlock { get; set; }
	public TextEditorTextSpan CloseCodeBlockTextSpan { get; set; }
	public int ScopeIndexKey { get; set; } = -1;

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.GetterOrSetterNode;
	
	#region ICodeBlockOwner_Methods
	public TypeReference GetReturnTypeReference()
	{
		return TypeFacts.Empty.ToTypeReference();
	}
	#endregion

	#if DEBUG	
	~GetterOrSetterNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.GetterOrSetterNode--;
	}
	#endif
}

