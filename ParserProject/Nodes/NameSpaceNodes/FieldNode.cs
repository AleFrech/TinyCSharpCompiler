using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class FieldNode
    {
        public string Name { get; set; }
        public ExpressionNode ExpressionNode { get; set; }
    }
}
