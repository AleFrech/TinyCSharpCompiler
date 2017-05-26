﻿using System;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class UsingDirectiveNode
    {
        public IdTypeNode IdNode { get; set; }
        public UsingDirectiveNode(IdTypeNode idNode)
        {
            IdNode = idNode;
        }

        public UsingDirectiveNode(){
            
        }
    }
}
