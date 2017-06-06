using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.TypeProductionNodes
{
    public class VoidTypeNode:TypeExpressionNode
    {
        public VoidTypeNode()
        {
            @Type = "void";
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
