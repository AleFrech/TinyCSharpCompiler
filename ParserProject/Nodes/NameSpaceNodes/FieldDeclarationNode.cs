using System;
using System.Collections.Generic;
using System.Text;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class FieldDeclarationNode:FieldMethodDeclarationNode
    {
        public List<FieldNode> FieldList { get; set; }
    }
}
