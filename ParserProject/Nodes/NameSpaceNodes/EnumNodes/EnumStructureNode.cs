using System;
using LexerProject.Tokens;

namespace ParserProject.Nodes.NameSpaceNodes.EnumNodes
{
    public class EnumStructureNode
    {
        public Token Name { get; set; }
        public EnumBodyNode Body {get;set;}
        public EnumStructureNode()
        {
        }
    }
}
