/*
// FindAllReferences
using DevIn.Common.RazorLib.Keys.Models;
using DevIn.Common.RazorLib.TreeViews.Models;
using DevIn.Extensions.CompilerServices.Syntax.Nodes;

namespace DevIn.Ide.RazorLib.FindAllReferences.Models;

public record struct FindAllReferencesState
{
	public static Key<TreeViewContainer> TreeViewContainerKey { get; } = Key<TreeViewContainer>.NewKey();

	public FindAllReferencesState()
	{
	}

	public TypeDefinitionNode? TypeDefinitionNode { get; init; }
	public string? NamespaceName { get; init; }
	public string? SyntaxName { get; init; }
}
*/