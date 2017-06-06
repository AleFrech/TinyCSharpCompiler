using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes.FieldMethodConstructorNodes
{
    public class FieldNode
    {
        public Token Name { get; set; }
        public ExpressionNode ExpressionNode { get; set; }
    }
}
