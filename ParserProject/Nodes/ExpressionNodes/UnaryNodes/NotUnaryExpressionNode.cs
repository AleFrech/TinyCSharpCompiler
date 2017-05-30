using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.UnaryNodes
{
    public class NotUnaryExpressionNode : UnaryExpressionNode
	{
		public NotUnaryExpressionNode(Token pvalue)
		{
			Value = pvalue;
		}


        public NotUnaryExpressionNode(){
            
        }

	}





}
