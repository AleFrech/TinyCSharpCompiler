using System;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
    public class PrimitiveEnumNode:PrimitiveTypeNode
    {
        public PrimitiveEnumNode()
        {
			@Type = CustomTypesTable.Instance.GetType("Enum");
        }
    }
}
