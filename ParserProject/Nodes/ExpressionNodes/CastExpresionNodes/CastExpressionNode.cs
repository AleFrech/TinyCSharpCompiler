using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.CastExpresionNodes
{
    public class CastExpressionNode:ExpressionNode
    {
        public ExpressionNode Left { get; set; }

        public ExpressionNode Right { get; set; }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
