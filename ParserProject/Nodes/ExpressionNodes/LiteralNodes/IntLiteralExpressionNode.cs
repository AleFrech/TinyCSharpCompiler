using System;
using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class IntLiteralExpressionNode:LiteralNodeExpression
    {
        public int Value { get; set; }

        public IntLiteralExpressionNode(Token lit)
        {
            literal = lit;
            if (literal.Lexeme.Contains("0x") || literal.Lexeme.Contains("0X"))
            {
                Value = Convert.ToInt32(literal.Lexeme, 16);
            }
            else if (literal.Lexeme.Contains("0b") || literal.Lexeme.Contains("0B"))
            {
                var x = literal.Lexeme.Substring(2);
                Value= Convert.ToInt32(x, 2);
            }
            else
            {
                Value = int.Parse(literal.Lexeme);
            }
        }

        public IntLiteralExpressionNode(){
            
        }

        public override CustomType EvaluateSemantic()
        {
            return CustomTypesTable.Instance.GetType("Int");
        }

		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = Value.ToString(),Type = "int"};
		}

    }
}
