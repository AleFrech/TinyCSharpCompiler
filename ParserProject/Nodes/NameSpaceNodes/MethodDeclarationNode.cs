using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.StatementNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class MethodDeclarationNode:FieldMethodDeclarationNode
    {
        public List<ParameterNode> ParameterList { get; set; }

        public List<StatementNode> StatementList { get; set; }
        public string Name { get; set; }
    }
}
