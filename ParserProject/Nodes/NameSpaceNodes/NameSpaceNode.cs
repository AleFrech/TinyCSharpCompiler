using System;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class NameSpaceNode:NameSpaceDeclarationNode
    {
        public IdTypeNode IdNode { get; set; }
        public CodeNode Code { get; set; }
        public NameSpaceNode()
        {
        }
    }
}
