using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes.FieldMethodConstructorNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes
{
    public class ClassNode : NameSpaceDeclarationNode
    {
        public string PrivacyModifier { get; set; }
        public string ClassModifier { get; set; }
        public Token NameToken { get; set; }
        public List<IdTypeNode> HeritageList { get; set; }

        public List<FieldMethodConstructor> FieldMethodConstructorList { get; set; }

        public override ExpressionCode GenerateCode()
        {

            var stringCode = "class " + NameToken.Lexeme;
            //       if(HeritageList!=null){
            //           if(HeritageList.Count>0){
            //var helper = new GenerationHelper();
            //stringCode += " extends ";
            //        foreach (var id in HeritageList)
            //        {
            //            var idName = helper.GetFullNameFromIdNode(id);
            //            if (!idName.Contains("I"){
            //                stringCode +=
            //            }
            //        }       
            //    }
            //}
            stringCode += "{\n";
            if (FieldMethodConstructorList != null)
                foreach (var cs in FieldMethodConstructorList)
                    stringCode += cs.GenerateCode().Code;
            stringCode += "}\n";
            return new ExpressionCode { Code = stringCode };
        }
    }
}
