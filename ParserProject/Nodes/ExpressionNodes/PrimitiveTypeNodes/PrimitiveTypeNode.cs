using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
    public abstract class PrimitiveTypeNode
    {
        public CustomType @Type { get; set; }
        public PrimitiveTypeNode()
        {
        }

		public abstract ExpressionCode GenerateCode();
    }
}
