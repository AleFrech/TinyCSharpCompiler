using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.ArrayNodes
{
    public class DimSeparatorNode:ExpressionNode
    {
        public DimSeparatorNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
