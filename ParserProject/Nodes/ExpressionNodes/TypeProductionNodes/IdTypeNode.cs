using System;
using LexerProject.Tokens;

namespace ParserProject.Nodes.ExpressionNodes.TypeProductionNodes
{
    public class IdTypeNode:TypeProductionNode
    {
        public Token Name { get; set; }
        public IdTypeNode IdNode { get; set; }

        public IdTypeNode(Token name, IdTypeNode idtype )
        {
            Name = name;
            IdNode = idtype;
        }

        public IdTypeNode(){
            
        }
    }
}
