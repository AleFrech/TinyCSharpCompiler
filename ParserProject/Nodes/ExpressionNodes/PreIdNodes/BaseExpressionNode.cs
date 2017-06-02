using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.PreIdNodes
{
    public class BaseExpressionNode:PreIdExpressionNode
    {
        public BaseExpressionNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
