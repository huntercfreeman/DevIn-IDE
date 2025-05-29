using DevIn.Extensions.CompilerServices.Syntax;
using DevIn.Extensions.CompilerServices.Syntax.Nodes;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Enums;
using DevIn.CompilerServices.CSharp.CompilerServiceCase;

namespace DevIn.CompilerServices.CSharp.ParserCase.Internals;

public static class ParseVariables
{
    /// <summary>Function invocation which uses the 'out' keyword.</summary>
    public static VariableDeclarationNode? HandleVariableDeclarationExpression(
        TypeClauseNode consumedTypeClauseNode,
        SyntaxToken consumedIdentifierToken,
        VariableKind variableKind,
        CSharpCompilationUnit compilationUnit,
        ref CSharpParserModel parserModel)
    {
    	VariableDeclarationNode variableDeclarationNode;

		variableDeclarationNode = new VariableDeclarationNode(
	        new TypeReference(consumedTypeClauseNode),
	        consumedIdentifierToken,
	        variableKind,
	        false);

        parserModel.Binder.BindVariableDeclarationNode(variableDeclarationNode, compilationUnit, ref parserModel);
        parserModel.CurrentCodeBlockBuilder.AddChild(variableDeclarationNode);
        return variableDeclarationNode;
    }
}
