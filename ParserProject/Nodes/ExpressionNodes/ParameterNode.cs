using System;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class ParameterNode:ExpressionNode
    {
        public TypeProductionNode typeNode { get; set; }
        public string Name { get; set; }
        public ParameterNode()
        {
        }
    }
}
