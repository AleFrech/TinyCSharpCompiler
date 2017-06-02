using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.TypeProductionNodes
{
    public class VoidTypeNode:TypeExpressionNode
    {
        public VoidTypeNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
