using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.ExtendsNodes
{
    public class ExtendsNode
    {
        public List<IdTypeNode> ListIdNodes { get; set; }

        public ExtendsNode(List<IdTypeNode> idnodelist)
        {
            ListIdNodes = idnodelist;
        }
    }
}
