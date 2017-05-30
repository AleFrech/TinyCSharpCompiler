using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.UnaryNodes
{
    public class IncUnaryExpressionNode : UnaryExpressionNode
	{
		public IncUnaryExpressionNode(Token pvalue)
		{
			Value = pvalue;
		}

        public IncUnaryExpressionNode(){
            
        }
	}





}
