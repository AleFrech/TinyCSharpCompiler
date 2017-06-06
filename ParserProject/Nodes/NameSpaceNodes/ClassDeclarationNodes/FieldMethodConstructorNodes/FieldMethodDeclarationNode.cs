using System;
using System.Collections.Generic;
using System.Text;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes.FieldMethodConstructorNodes
{
    public class FieldMethodDeclarationNode
    {
		public bool IsMethod { get; set; }
		public bool IsField { get; set; }
        public List<FieldNode> FieldList { get; set; }
        public MethodDeclarationNode Method { get;  set; }
    }
}
