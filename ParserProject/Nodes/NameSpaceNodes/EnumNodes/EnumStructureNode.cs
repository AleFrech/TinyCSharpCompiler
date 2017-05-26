using System;
namespace ParserProject.Nodes.NameSpaceNodes.EnumNodes
{
    public class EnumStructureNode
    {
        public string Name { get; set; }
        public EnumBodyNode Body {get;set;}
        public EnumStructureNode()
        {
        }
    }
}
