using System;
using ParserProject.Generation;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
    public class PrimitiveBoolNode:PrimitiveTypeNode
    {
        public PrimitiveBoolNode()
        {
            @Type = CustomTypesTable.Instance.GetType("Bool");
        }

        public override ExpressionCode GenerateCode()
        {
            return new ExpressionCode { Code = "bool" }; 
        }
    }
}
