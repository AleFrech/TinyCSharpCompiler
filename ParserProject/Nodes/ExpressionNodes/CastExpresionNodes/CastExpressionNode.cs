using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.CastExpresionNodes
{
    public class CastExpressionNode:ExpressionNode
    {
        public ExpressionNode Left { get; set; }

        public ExpressionNode Right { get; set; }

        public override CustomType EvaluateSemantic()
        {
            return null;
        }

        public override ExpressionCode GenerateCode()
        {
            return new ExpressionCode{Code=Right.GenerateCode().Code,Type = Right.GenerateCode().Type};
        }
    }
}
