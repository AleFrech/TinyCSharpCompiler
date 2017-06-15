using System;
using ParserProject.Generation;
using ParserProject.Semantic;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
    public class PrimitiveEnumNode:PrimitiveTypeNode
    {
        public PrimitiveEnumNode()
        {
			@Type = CustomTypesTable.Instance.GetType("Enum");
        }

		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = "enum" };
		}
    }
}
