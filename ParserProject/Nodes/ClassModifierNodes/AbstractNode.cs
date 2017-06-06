using System;
using System.Collections.Generic;
using System.Text;

namespace ParserProject.Nodes.ClassModifierNodes
{
    public class AbstractNode:ClassModifierNode
    {
        public AbstractNode()
        {
            Value = "abstract";
        }
    }
}
