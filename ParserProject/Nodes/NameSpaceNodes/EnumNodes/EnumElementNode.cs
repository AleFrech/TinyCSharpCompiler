using System;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.NameSpaceNodes.EnumNodes
{
    public class EnumElementNode
    {
        public string Name { get; set; }
        public ExpressionNode Expression {get;set;}
        public EnumElementNode()
        {
        }
    }
}
