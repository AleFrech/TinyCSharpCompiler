using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class AssignationNodeStatement:StatementNode
    {
        public ExpressionNode LeftValue { get; set; }
        public ExpressionNode RightValue { get; set; }
    }
}
