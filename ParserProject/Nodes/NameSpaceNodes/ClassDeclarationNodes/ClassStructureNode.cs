using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ClassModifierNodes;
using ParserProject.Nodes.ExtendsNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes
{
    public class ClassStructureNode
    {
        public  ClassModifierNode ModifierNode { get; set; }
        public string Name { get; set; }
        public ExtendsNode ExtendsNode { get; set; }
        public ClassBodyNode Body { get; set; }
    }
}
