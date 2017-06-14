using System;
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
            throw new NotImplementedException();
        }
    }
}
