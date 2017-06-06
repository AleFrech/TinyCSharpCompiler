using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class PrimitiveTypeAccessorStatement:StatementNode
    {
        public PrimitiveTypeNode Type { get; set; }
        public Token Name { get; set; }

        public AccesorExpressionNode Accesor { get; set; }
        public override void EvaluateSemantic()
        {
            throw new System.NotImplementedException();
        }
    }
}
