using System;
using System.Collections.Generic;
using System.Text;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class InitalizerValueNode:ExpressionNode
    {
        public List<ExpressionNode> ExpressionList { get; set; }
    }
}
