using System;
using LexerProject.Tokens;
using ParserProject.Generation;
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
           return CustomTypesTable.Instance.GetType("Char");
        }

		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = "\'"+Value.ToString()+"\'",Type = "char"};
		}
    }
}
