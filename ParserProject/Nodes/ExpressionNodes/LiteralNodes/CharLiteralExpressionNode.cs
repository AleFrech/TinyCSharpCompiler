using System;
using LexerProject.Tokens;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class CharLiteralExpressionNode:LiteralNodeExpression
    {
        public char Value { get; set; }

        public CharLiteralExpressionNode(Token lit)
        {
            literal = lit;
            Value = char.Parse(literal.Lexeme);
        }

        public CharLiteralExpressionNode(){
            
        }

        public override CustomType EvaluateSemantic()
        {
           return TypesTable.Instance.GetType("Char");
        }
    }
}
