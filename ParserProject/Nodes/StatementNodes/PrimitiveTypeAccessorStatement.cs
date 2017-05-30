using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class PrimitiveTypeAccessorStatement:StatementNode
    {
        public PrimitiveTypeNode Type { get; set; }
        public Token Name { get; set; }

        public AccesorExpressionNode Accesor { get; set; }
    }
}
