using System;
namespace ParserProject.Nodes.ExpressionNodes.TypeProductionNodes
{
    public abstract class TypeExpressionNode:ExpressionNode
    {
        public string @Type { get; set; }
        public TypeExpressionNode()
        {
            
        }
    }
}
