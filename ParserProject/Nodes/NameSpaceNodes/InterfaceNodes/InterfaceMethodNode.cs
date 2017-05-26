using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.NameSpaceNodes.InterfaceNodes
{
    public class InterfaceMethodNode
    {
        public TypeExpressionNode TypeNode { get; set; }
        public string Name { get; set; }
        public List<ParameterNode> ParameterList { get; set; }

    }
}
