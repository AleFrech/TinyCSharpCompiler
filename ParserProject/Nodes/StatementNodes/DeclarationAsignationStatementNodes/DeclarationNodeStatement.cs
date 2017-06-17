using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.StatementNodes.DeclarationAsignationStatementNodes
{
    public class DeclarationNodeStatement :DeclarationAsignationStatement
    {
        public TypeExpressionNode Type { get; set; }
        public List<DeclaratorNode> DeclarationList { get; set; }

        public override ExpressionCode GenerateCode()
        {
            var stringCode = "let ";
            for (int i = 0; i < DeclarationList.Count; i++)
            {
                if (DeclarationList[i] == DeclarationList[DeclarationList.Count - 1])
                {
                    stringCode += DeclarationList[i].GenerateCode().Code;
                }
                else
                {
                    stringCode += DeclarationList[i].GenerateCode().Code+" ,";
                }
            }
            return new ExpressionCode{Code =stringCode+" ;"};
        }
    }
}
