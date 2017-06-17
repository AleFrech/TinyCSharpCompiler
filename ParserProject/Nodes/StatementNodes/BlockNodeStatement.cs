using System;
using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class BlockNodeStatement:StatementNode
    {
        public List<StatementNode> StatementList { get; set; }

        public BlockNodeStatement(List<StatementNode> statementList)
        {
            StatementList = statementList;
        }

        public BlockNodeStatement(){
            
        }

        public override void EvaluateSemantic()
        {
        }

        public override ExpressionCode GenerateCode()
        {
            var stringCode = "";
            foreach(var s in StatementList){
                stringCode += s.GenerateCode().Code;
            }
            return new ExpressionCode { Code = stringCode };
        }
    }
}
