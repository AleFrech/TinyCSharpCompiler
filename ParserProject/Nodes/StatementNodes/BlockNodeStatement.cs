using System;
using System.Collections.Generic;

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
    }
}
