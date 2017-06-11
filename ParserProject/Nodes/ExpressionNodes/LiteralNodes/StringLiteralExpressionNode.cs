using System;
using LexerProject.Tokens;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class StringLiteralExpressionNode:LiteralNodeExpression
    {
        public string Value { get; set; }

        public StringLiteralExpressionNode(Token lit)
        {
            literal = lit;
            Value = literal.Lexeme;
        }

        public StringLiteralExpressionNode(){
            
        }

        public override CustomType EvaluateSemantic()
        {
            return CustomTypesTable.Instance.GetType("String");
        }
    }
}
