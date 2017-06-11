using System;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic.CustomTypes;

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

        public override void EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
