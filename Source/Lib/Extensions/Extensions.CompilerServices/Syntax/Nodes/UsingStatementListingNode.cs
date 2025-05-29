namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class UsingStatementListingNode : ISyntaxNode
{
	public UsingStatementListingNode()
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.UsingStatementListingNode++;
		#endif
	}

	/// <summary>
	/// Note: don't store as ISyntax in order to avoid boxing.
	/// If someone explicitly invokes 'GetChildList()' then box at that point
	/// but 'GetChildList()' is far less likely to be invoked for this type.
	/// </summary>
	public List<(SyntaxToken KeywordToken, SyntaxToken NamespaceIdentifier)> UsingStatementTupleList { get; set; } = new();

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.UsingStatementListingNode;

	#if DEBUG	
	~UsingStatementListingNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.UsingStatementListingNode--;
	}
	#endif
}