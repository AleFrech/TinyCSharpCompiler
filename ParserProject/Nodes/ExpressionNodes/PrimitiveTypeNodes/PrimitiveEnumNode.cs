using System;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
    public class PrimitiveEnumNode:PrimitiveTypeNode
    {
        public PrimitiveEnumNode()
        {
			@Type = TypesTable.Instance.GetType("Enum");
        }
    }
}
