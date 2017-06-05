using System;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
    public class PrimitiveBoolNode:PrimitiveTypeNode
    {
        public PrimitiveBoolNode()
        {
            @Type = TypesTable.Instance.GetType("Bool");
        }
    }
}
