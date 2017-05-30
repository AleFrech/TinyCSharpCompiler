using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.UnaryNodes
{
    public class ComplementUnaryExpressionNode : UnaryExpressionNode
	{
		public ComplementUnaryExpressionNode(Token pvalue)
		{
			Value = pvalue;
		}

        public ComplementUnaryExpressionNode(){
            
        }
	}





}
