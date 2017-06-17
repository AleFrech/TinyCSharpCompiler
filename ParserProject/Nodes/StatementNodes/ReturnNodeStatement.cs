using System;
using ParserProject.Generation;
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
        }

        public override ExpressionCode GenerateCode()
        {
            var stringCode = "return ";
            if(Expresion!=null){
                stringCode += Expresion.GenerateCode().Code;
            }
            stringCode += " ;\n ";
            return new ExpressionCode { Code = stringCode };
        }
    }
}
