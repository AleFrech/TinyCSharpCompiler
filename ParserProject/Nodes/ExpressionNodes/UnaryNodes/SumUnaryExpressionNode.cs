using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.UnaryNodes
{
    public class SumUnaryExpressionNode:UnaryExpressionNode{
        public SumUnaryExpressionNode(Token pvalue){
            Value = pvalue;
        }

        public SumUnaryExpressionNode(){
            
        }
    }





}
