using System;
using System.Collections.Generic;
using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.NameSpaceNodes.InterfaceNodes
{
    public class InterfaceMethodNode
    {
        public TypeExpressionNode TypeNode { get; set; }
        public Token Name { get; set; }
        public List<ParameterNode> ParameterList { get; set; }

        public InterfaceMethodNode(){
            
        }

    }
}
