using System;
using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.NameSpaceNodes.EnumNodes
{
    public class EnumElementNode
    {
        public Token Name { get; set; }
        public ExpressionNode Expression {get;set;}
        public EnumElementNode()
        {
        }

		public ExpressionCode GenerateCode()
		{
            var stringCode =Name.Lexeme;
            if (Expression != null)
                stringCode += " = " + Expression.GenerateCode().Code;
            return new ExpressionCode { Code = stringCode };
			
		}
    }
}
