using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.TypeProductionNodes
{
    public class VarTypeNode:TypeExpressionNode
    {
        public VarTypeNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
