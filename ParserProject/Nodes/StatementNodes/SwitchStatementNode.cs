using System;
using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class SwitchStatementNode : StatementNode
    {
        public ExpressionNode ExpressiontoEvaluate { get; set; }
        public List<CaseNodeStatement> Cases { get; set; }
        public DefaultCaseNodeStatement DefaultNode {get;set;}

        public SwitchStatementNode(ExpressionNode expToEvaluate,List<CaseNodeStatement> cases, DefaultCaseNodeStatement defaultNode)
        {
            ExpressiontoEvaluate = expToEvaluate;
            Cases = cases;
            DefaultNode = defaultNode;
        }

        public SwitchStatementNode(){
            
        }

        public override void EvaluateSemantic()
        {
            var conditionType = ExpressiontoEvaluate.EvaluateSemantic();

            foreach(var @case in Cases){
                @case.EvaluateSemantic(conditionType);
            }
            DefaultNode.EvaluateSemantic();
        }
    }
}
