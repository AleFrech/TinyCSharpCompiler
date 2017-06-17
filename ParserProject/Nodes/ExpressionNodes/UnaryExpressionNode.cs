using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class UnaryExpressionNode:ExpressionNode
    {
        public string Unary { get; set; }
        public ExpressionNode Expression { get; set; }

        public UnaryExpressionNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            return Expression.EvaluateSemantic();
        }

        public override ExpressionCode GenerateCode()
        {
            return new ExpressionCode { Code = Unary + " " + Expression.GenerateCode().Code };
        }
    }
}
