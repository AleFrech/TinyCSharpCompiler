using System;
using System.Collections.Generic;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public  class CodeNode
    {
        public List<UsingDirectiveNode> UsingDirectiveList { get; set; }
        public List<NameSpaceDeclarationNode> NameSpaceDeclarationList { get; set; }
        public CodeNode()
        {
        }
    }
}
