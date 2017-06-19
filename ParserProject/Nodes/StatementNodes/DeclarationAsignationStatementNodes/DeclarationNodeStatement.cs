using System.Collections.Generic;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Semantic;

namespace ParserProject.Nodes.StatementNodes.DeclarationAsignationStatementNodes
{
    public class DeclarationNodeStatement :DeclarationAsignationStatement
    {
        public TypeExpressionNode Type { get; set; }
        public List<DeclaratorNode> DeclarationList { get; set; }

        public override ExpressionCode GenerateCode()
        {
            var type = Type.GenerateCode().Type;

			foreach (var dec in DeclarationList){
                SymbolTable.vars[dec.Name.Lexeme] = type;
            }


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
