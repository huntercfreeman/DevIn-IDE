using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Enums;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

/// <summary>
/// I just realized as I made this type,
/// is it "global" or "top level statements"?
///
/// Now that I think about it I think
/// this should be named top-level-statements.
///
/// But I'm in the middle of a lot of changes
/// and cannot mess with the name at the moment.
///
/// --------------------------------------------
///
/// When invoking 'GetChildList()'
/// this will return 'CodeBlockNode.GetChildList();'
/// if 'CodeBlockNode' is not null.
/// </summary>
public sealed class GlobalCodeBlockNode : ICodeBlockOwner
{
	public GlobalCodeBlockNode()
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.GlobalCodeBlockNode++;
		#endif
	}

	// ICodeBlockOwner properties.
	public ScopeDirectionKind ScopeDirectionKind => ScopeDirectionKind.Both;
	public TextEditorTextSpan OpenCodeBlockTextSpan { get; set; }
	public CodeBlock CodeBlock { get; set; }
	public TextEditorTextSpan CloseCodeBlockTextSpan { get; set; }
	public int ScopeIndexKey { get; set; } = -1;

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.GlobalCodeBlockNode;

	#region ICodeBlockOwner_Methods
	public TypeReference GetReturnTypeReference()
	{
		return TypeFacts.Empty.ToTypeReference();
	}
	#endregion

	#if DEBUG	
	~GlobalCodeBlockNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.GlobalCodeBlockNode--;
	}
	#endif
}
