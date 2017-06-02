using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.PreIdNodes
{
    public class ThisExpressionNode:PreIdExpressionNode
    {
        public ThisExpressionNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
