using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
