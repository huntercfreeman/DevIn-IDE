using DevIn.Extensions.CompilerServices.Syntax.Nodes.Interfaces;

namespace DevIn.Extensions.CompilerServices.Syntax.Nodes;

public sealed class TupleExpressionNode : IExpressionNode
{
	public TupleExpressionNode()
	{
		#if DEBUG
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.TupleExpressionNode++;
		#endif
	}

	public TypeReference ResultTypeReference { get; } = TypeFacts.Empty.ToTypeReference();

	public List<IExpressionNode> InnerExpressionList { get; } = new();

	public bool IsFabricated { get; init; }
	public SyntaxKind SyntaxKind => SyntaxKind.TupleExpressionNode;

	#if DEBUG	
	~TupleExpressionNode()
	{
		DevIn.Common.RazorLib.Installations.Models.DevInDebugSomething.TupleExpressionNode--;
	}
	#endif
}
