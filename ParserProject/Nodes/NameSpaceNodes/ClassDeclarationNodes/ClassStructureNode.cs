using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
using ParserProject.Nodes.ExtendsNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes
{
    public class ClassStructureNode
    {
        public string ClassModifierNode { get; set; }
        public Token Name { get; set; }
        public ExtendsNode ExtendsNode { get; set; }
        public ClassBodyNode Body { get; set; }
    }
}
