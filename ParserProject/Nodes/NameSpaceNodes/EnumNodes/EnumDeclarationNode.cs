using System;
namespace ParserProject.Nodes.NameSpaceNodes.EnumNodes
{
    public class EnumDeclarationNode : NameSpaceDeclarationNode
    {
        public string Name { get; set; }
        public EnumBodyNode Body {get;set;}
        public EnumDeclarationNode()
        {
        }
    }
}
