namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class PreprocessorLibraryReferenceStatementNode : ISyntaxNode
{
	public PreprocessorLibraryReferenceStatementNode(
		SyntaxToken includeDirectiveSyntaxToken,
		SyntaxToken libraryReferenceSyntaxToken)
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.PreprocessorLibraryReferenceStatementNode++;
		#endif
	
		IncludeDirectiveSyntaxToken = includeDirectiveSyntaxToken;
		LibraryReferenceSyntaxToken = libraryReferenceSyntaxToken;
	}

	public SyntaxToken IncludeDirectiveSyntaxToken { get; }
	public SyntaxToken LibraryReferenceSyntaxToken { get; }

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.PreprocessorLibraryReferenceStatementNode;

	#if DEBUG	
	~PreprocessorLibraryReferenceStatementNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.PreprocessorLibraryReferenceStatementNode--;
	}
	#endif
}