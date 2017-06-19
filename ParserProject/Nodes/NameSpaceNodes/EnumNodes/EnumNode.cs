using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
using ParserProject.Generation;

namespace ParserProject.Nodes.NameSpaceNodes.EnumNodes
{
    public class EnumNode:NameSpaceDeclarationNode
    {
        public string PrivacyModifier { get; set; }
        public Token NameToken { get; set; }

        public List<EnumElementNode> EnumElementList { get; set; }


        public override ExpressionCode GenerateCode()
		{
            //Pending full name with namespace
            var stringCode = "const "+NameToken.Lexeme;
            stringCode += " = { ";
            for (int i = 0; i < EnumElementList.Count;i++){
                if (EnumElementList[i] == EnumElementList[EnumElementList.Count - 1])
                    stringCode += EnumElementList[i].GenerateCode().Code;
                else
                    stringCode += EnumElementList[i].GenerateCode().Code+" , ";
            }
            stringCode += " }";
            return new ExpressionCode { Code = stringCode };
		}

    }
}
