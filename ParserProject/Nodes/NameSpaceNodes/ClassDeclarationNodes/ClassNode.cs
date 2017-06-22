using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            var fieldList = FieldMethodConstructorList.Where(x => x.IsField).ToList();

            var stringCode = "class " + NameToken.Lexeme;
            if(HeritageList!=null){
                if(HeritageList.Count>0){
	                var helper = new GenerationHelper();
                    var idname = helper.GetFullNameFromIdNode(HeritageList[0]);
                    if (Regex.IsMatch(idname,"^[I][A-Z].*$"))
                    {
                        stringCode += " extends ";
                        stringCode += idname;
                    }
                          
                }
            }
            stringCode += "{\n";
            //normal fields
            stringCode += "_define() { \n";
            foreach (var field in fieldList.Where(x=>!x.IsStatic)){
                foreach (var f in field.FieldList){
                    stringCode += f.GenerateCode(field.Type.GenerateCode().Type).Code+"\n";
                }
               
            }
            stringCode += "}\n";
            //static fields
			foreach (var field in fieldList.Where(x => x.IsStatic))
			{
				foreach (var f in field.FieldList)
				{
                    stringCode += "static get " + f.Name.Lexeme + " () {\n";

					if (f.ExpressionNode != null)
					{
                        stringCode +="return "+f.ExpressionNode.GenerateCode().Code+";\n";

					}
					else
					{
                        if (field.Type.GenerateCode().Type == "int")
                            stringCode +="return 0;\n";
						else if (field.Type.GenerateCode().Type == "bool")
                            stringCode += "return false;";
						else if (field.Type.GenerateCode().Type == "float")
                            stringCode += "return 0.0;";
						else if (field.Type.GenerateCode().Type == "char")
                            stringCode += @"return '\0';";
						else
                            stringCode += "return null;";
					}

                    stringCode += "}\n";
				}

			}
            var methodList = FieldMethodConstructorList.Where(x => x.IsMethod).ToList();
            //normal methods




			stringCode += "}\n";
            return new ExpressionCode { Code = stringCode };
        }
    }
}
