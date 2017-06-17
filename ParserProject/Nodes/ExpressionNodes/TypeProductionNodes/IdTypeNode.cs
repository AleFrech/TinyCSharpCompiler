using System;
using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

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

        public override CustomType EvaluateSemantic()
        {
            return null;
        }

        public override ExpressionCode GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
