using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.UnaryNodes
{
    public class SubUnaryExpressionNode : UnaryExpressionNode
	{
		public SubUnaryExpressionNode(Token pvalue)
		{
			Value = pvalue;
		}

        public SubUnaryExpressionNode(){
            
        }
	}





}
