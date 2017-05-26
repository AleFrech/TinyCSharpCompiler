using System;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class ReturnNodeStatement:StatementNode
    {
        public ExpressionNode Expresion { get; set; }

        public ReturnNodeStatement(ExpressionNode expresion )
        {
            Expresion = expresion;
        }

        public ReturnNodeStatement(){
            
        }
    }
}
