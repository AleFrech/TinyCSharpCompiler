using System;
using ParserProject.Nodes.ExpressionNodes.UnaryNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class PrimaryExpressionNode:ExpressionNode
    {
        public PrimaryExpressionNode()
        {
            
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
