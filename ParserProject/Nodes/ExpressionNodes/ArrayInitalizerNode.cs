using System;
using System.Collections.Generic;
using System.Text;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class ArrayInitalizerNode:ExpressionNode
    {
        public List<ExpressionNode> ExpressionList { get; set; }
    }
}
