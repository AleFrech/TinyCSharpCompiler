using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class FieldNode
    {
        public Token Name { get; set; }
        public ExpressionNode ExpressionNode { get; set; }
    }
}
