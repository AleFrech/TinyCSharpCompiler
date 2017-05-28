using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class ConstructorInitalizerNode
    {
    }

    public class BaseConstructor : ConstructorInitalizerNode
    {
        public List<ExpressionNode> ArgumeList { get; set; }
    }

    public class ThisConstructor : ConstructorInitalizerNode
    {
        public List<ExpressionNode> ArgumeList { get; set; }
    }
}
