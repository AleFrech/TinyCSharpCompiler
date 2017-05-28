using System;
using System.Collections.Generic;
using System.Text;

namespace ParserProject.Nodes.ExpressionNodes.NewExpressionNodes.NewCreationNodes
{
    public class MemberNode : ExpressionNode
    {
        public string Name { get; set; }
        public List<ExpressionNode> ExpressionList { get; set; }
    }
}
