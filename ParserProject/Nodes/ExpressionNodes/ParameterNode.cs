using System;
using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class ParameterNode:ExpressionNode
    {
        public TypeProductionNode typeNode { get; set; }
        public Token Name { get; set; }
        public ParameterNode()
        {
        }
    }
}
