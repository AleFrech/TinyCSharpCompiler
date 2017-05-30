using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.UnaryNodes
{
    public class DecUnaryExpressionNode : UnaryExpressionNode
	{
		public DecUnaryExpressionNode(Token pvalue)
		{
			Value = pvalue;
		}

        public DecUnaryExpressionNode(){
            
        }

	}





}
