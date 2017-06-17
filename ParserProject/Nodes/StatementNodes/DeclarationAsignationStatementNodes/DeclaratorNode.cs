using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes.DeclarationAsignationStatementNodes
{
    public class DeclaratorNode
    {
        public Token Name { get; set; }
        public ExpressionNode Expression { get; set; }

        public  ExpressionCode GenerateCode()
        {
            var stringCode = " " + Name.Lexeme;
            if(Expression!=null)
                stringCode+=" = "+Expression.GenerateCode().Code;
            return new ExpressionCode { Code = stringCode };
        }
    }
}
