using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes.DeclarationAsignationStatementNodes
{
    public class DeclaratorNode
    {
        public Token Name { get; set; }
        public ExpressionNode Expression { get; set; }
    }
}
