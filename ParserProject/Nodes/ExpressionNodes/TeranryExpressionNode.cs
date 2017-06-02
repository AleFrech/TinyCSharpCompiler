using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class TeranryExpressionNode:ExpressionNode
    {
		public ExpressionNode Condition { get; set; }
		public ExpressionNode TrueExpression { get; set; }
        public ExpressionNode FalseExpression { get; set; }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
