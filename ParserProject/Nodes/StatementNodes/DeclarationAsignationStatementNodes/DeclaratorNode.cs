using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes.DeclarationAsignationStatementNodes
{
    public class DeclaratorNode
    {
        public string Name { get; set; }
        public ExpressionNode Expression { get; set; }
    }
}
