using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.TextEditor.RazorLib.Decorations.Models;
using DevIn.Extensions.CompilerServices;
using DevIn.Extensions.CompilerServices.Syntax;
using DevIn.Extensions.CompilerServices.Syntax.Nodes;
using DevIn.Extensions.CompilerServices.Syntax.Nodes.Enums;

namespace DevIn.CompilerServices.CSharp.Facts;

public partial class CSharpFacts
{
    public class Types
    {
        public static readonly TypeDefinitionNode Void = new(
            AccessModifierKind.Public,
            false,
            StorageModifierKind.Class,
            new SyntaxToken(SyntaxKind.IdentifierToken, new TextEditorTextSpan(0, "void".Length, (byte)GenericDecorationKind.None, ResourceUri.Empty, "void")),
            typeof(void),
            default,
            primaryConstructorFunctionArgumentListing: default,
            TypeFacts.NotApplicable.ToTypeReference(),
            string.Empty
            // FindAllReferences
            // , referenceHashSet: new()
            )
            {
            	IsKeywordType = true
            };

        public static readonly TypeDefinitionNode Int = new(
            AccessModifierKind.Public,
            false,
            StorageModifierKind.Class,
            new SyntaxToken(SyntaxKind.IdentifierToken, new TextEditorTextSpan(0, "int".Length, (byte)GenericDecorationKind.None, ResourceUri.Empty, "int")),
            typeof(int),
            default,
            primaryConstructorFunctionArgumentListing: default,
            TypeFacts.NotApplicable.ToTypeReference(),
            string.Empty
            // FindAllReferences
            // , referenceHashSet: new()
            )
            {
            	IsKeywordType = true
            };

        public static readonly TypeDefinitionNode Char = new(
            AccessModifierKind.Public,
            false,
            StorageModifierKind.Class,
            new SyntaxToken(SyntaxKind.IdentifierToken, new TextEditorTextSpan(0, "char".Length, (byte)GenericDecorationKind.None, ResourceUri.Empty, "char")),
            typeof(char),
            default,
            primaryConstructorFunctionArgumentListing: default,
            TypeFacts.NotApplicable.ToTypeReference(),
            string.Empty
            // FindAllReferences
            // , referenceHashSet: new()
			)
            {
            	IsKeywordType = true
            };

        public static readonly TypeDefinitionNode String = new(
            AccessModifierKind.Public,
            false,
            StorageModifierKind.Class,
            new SyntaxToken(SyntaxKind.IdentifierToken, new TextEditorTextSpan(0, "string".Length, (byte)GenericDecorationKind.None, ResourceUri.Empty, "string")),
            typeof(string),
            default,
            primaryConstructorFunctionArgumentListing: default,
            TypeFacts.NotApplicable.ToTypeReference(),
            string.Empty
			// FindAllReferences
			// ,referenceHashSet: new()
			)
            {
            	IsKeywordType = true
            };

        public static readonly TypeDefinitionNode Bool = new(
            AccessModifierKind.Public,
            false,
            StorageModifierKind.Class,
            new SyntaxToken(SyntaxKind.IdentifierToken, new TextEditorTextSpan(0, "bool".Length, (byte)GenericDecorationKind.None, ResourceUri.Empty, "bool")),
            typeof(bool),
            default,
            primaryConstructorFunctionArgumentListing: default,
            TypeFacts.NotApplicable.ToTypeReference(),
            string.Empty
			// FindAllReferences
			// ,referenceHashSet: new()
			)
            {
            	IsKeywordType = true
            };

        public static readonly TypeDefinitionNode Var = new(
            AccessModifierKind.Public,
            false,
            StorageModifierKind.Class,
            new SyntaxToken(SyntaxKind.IdentifierToken, new TextEditorTextSpan(0, "var".Length, (byte)GenericDecorationKind.None, ResourceUri.Empty, "var")),
            typeof(void),
            default,
            primaryConstructorFunctionArgumentListing: default,
            TypeFacts.NotApplicable.ToTypeReference(),
            string.Empty
            // FindAllReferences
            // ,referenceHashSet: new()
            )
            {
            	IsKeywordType = true
            };

        public static readonly IReadOnlyList<TypeDefinitionNode> TypeDefinitionNodes = new[]
        {
            Void,
            Int,
            String,
            Bool,
            Var
        }.ToList();
    }
}