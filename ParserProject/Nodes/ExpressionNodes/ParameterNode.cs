using System;
using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class ParameterNode:ExpressionNode
    {
        public TypeProductionNode typeNode { get; set; }
        public Token Name { get; set; }
        public ParameterNode()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            return null;
        }

        public override ExpressionCode GenerateCode()
        {
            SymbolTable.vars[Name.Lexeme] = typeNode.GenerateCode().Type;
            return new ExpressionCode
            {
                Code = Name.Lexeme,
                Type = typeNode.GenerateCode().Type
                    
            };
        }
    }
}
