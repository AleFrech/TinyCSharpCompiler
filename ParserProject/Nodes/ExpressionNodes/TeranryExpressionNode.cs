using System;
using ParserProject.Generation;
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
            return Condition.EvaluateSemantic();
        }

        public override ExpressionCode GenerateCode()
        {
            var stringCode = Condition.GenerateCode().Code;
            stringCode += " ? " + TrueExpression.GenerateCode().Code;
            stringCode += " : " + FalseExpression.GenerateCode().Code;
            return new ExpressionCode { Code = stringCode ,Type = TrueExpression.GenerateCode().Type};
        }
    }
}
