using System;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes
{
    public abstract class PrimitiveTypeNode
    {
        public CustomType @Type { get; set; }
        public PrimitiveTypeNode()
        {
        }
    }
}
