using System;
using ParserProject.Generation;
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
            return null;
        }

        public override ExpressionCode GenerateCode()
        {
            return new ExpressionCode { Code = "var" };
        }
    }
}
