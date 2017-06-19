﻿using System;
using ParserProject.Generation;
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

		public  ExpressionCode GenerateCode()
		{
			var helper = new GenerationHelper();
			var idName = helper.GetFullNameFromIdNode(IdNode);
            return new ExpressionCode { Code = idName };
			
		}
    }
}
