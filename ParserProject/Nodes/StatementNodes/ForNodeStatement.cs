using System;
using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.StatementNodes.DeclarationAsignationStatementNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class ForNodeStatement:StatementNode
    {
        public StatementNode DeclarationAsignation { get; set; }
        public ExpressionNode Expression { get; set; }
        public List<ExpressionNode> ExpressionList { get; set; }
        public List<StatementNode> ListStatement { get; set; }
        public ForNodeStatement(StatementNode declarationAsignation, ExpressionNode expression, List<ExpressionNode> expressionList, List<StatementNode> statementList)
        {
            DeclarationAsignation = declarationAsignation;
            Expression = expression;
            ListStatement = statementList;
            ExpressionList = expressionList;
        }

        public ForNodeStatement(){
            
        }

        public override void EvaluateSemantic()
        {
        }

        public override ExpressionCode GenerateCode()
        {
            var stringCode = "for( ";
            stringCode += DeclarationAsignation != null ? DeclarationAsignation.GenerateCode().Code : " ";
            stringCode += " ; ";
			stringCode += Expression != null ? Expression.GenerateCode().Code : " ";
            stringCode += " ; ";
            if(ExpressionList==null){
                stringCode += " ";
            }else{
				for (int i = 0; i < ExpressionList.Count; i++)
				{
					if (ExpressionList[i] == ExpressionList[ExpressionList.Count - 1])
						stringCode += ExpressionList[i].GenerateCode().Code;
					else
						stringCode += ExpressionList[i].GenerateCode().Code + ",";
				}
            }
            stringCode += ") { \n";
            foreach (var exp in ListStatement)
                stringCode += exp.GenerateCode().Code;
            stringCode += "}\n";

            return new ExpressionCode { Code = stringCode };
        }
    }
}
