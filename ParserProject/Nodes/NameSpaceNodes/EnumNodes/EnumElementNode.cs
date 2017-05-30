using System;
using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.NameSpaceNodes.EnumNodes
{
    public class EnumElementNode
    {
        public Token Name { get; set; }
        public ExpressionNode Expression {get;set;}
        public EnumElementNode()
        {
        }
    }
}
