using System;
namespace ParserProject.Nodes.ExpressionNodes
{
    public class TeranryExpressionNode:ExpressionNode
    {
		public ExpressionNode Condition { get; set; }
		public ExpressionNode TrueExpression { get; set; }
        public ExpressionNode FalseExpression { get; set; }
    }
}
