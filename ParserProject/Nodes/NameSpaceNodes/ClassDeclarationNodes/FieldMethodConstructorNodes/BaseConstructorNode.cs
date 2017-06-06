using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes.FieldMethodConstructorNodes
{
    public class BaseConstructorNode
    {
        public string BaseOrThis { get; set; }
        public List<ExpressionNode> ArgumeList { get; set; }
    }
}
