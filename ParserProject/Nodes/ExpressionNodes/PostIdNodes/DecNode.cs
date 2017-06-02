using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.PostIdNodes
{
    public class DecNode:PostIdExpressionNode
    {
        public DecNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
