using System;
using System.Collections.Generic;
using System.Text;

namespace ParserProject.Nodes.ClassModifierNodes
{
    public class StaticNode:ClassModifierNode
    {
        public StaticNode()
        {
            Value = "static";
        }
    }
}
