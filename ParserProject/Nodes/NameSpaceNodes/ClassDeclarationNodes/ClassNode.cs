using System;
using System.Collections.Generic;
using System.Linq;
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
            var helper = new GenerationHelper();
            var fieldList = FieldMethodConstructorList.Where(x => x.IsField).ToList();

            var stringCode = "class " + NameToken.Lexeme;
            if(HeritageList!=null){
                if(HeritageList.Count>0){
	               
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
            var overlodMethods = new Dictionary<string, List<FieldMethodConstructor>>();
            foreach (var method in methodList)
            {
                var current = overlodMethods.GetOrUpdate(method.Method.Name.Lexeme, new List<FieldMethodConstructor>());
                current.Add(method);
            }
            //normal methods
            foreach (var methods in overlodMethods)
            {
                if (methods.Value.First().IsStatic)
                    stringCode += "static";
                stringCode += "function " + methods.Key + "( ...args ) {\n";
                stringCode += "let methods ={\n";

                foreach (var method in methods.Value)
                {

                    stringCode += methods.Key + "_" + method.Method.ParameterList.Count;
                    stringCode += " : function";
                    stringCode += " ( "+String.Join(",",method.Method.ParameterList.Select(x=>x.Name))+" ) {\n";
                    foreach (var st in method.Method.StatementList)
                    {
                        stringCode += st.GenerateCode().Code+"\n";
                    }
                    stringCode += "}\n";
                }
                stringCode += "}\n";

                stringCode += @"let name = " + methods.Key + @"+ ""_"" + args.length;
";
                stringCode += "return methods[name](...args);\n";
            }
            stringCode += "}\n";





            stringCode += "}\n";
            return new ExpressionCode { Code = stringCode };
        }
    }

    public static class Extensions
    {
        public static TValue GetOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue update)
        {
            if (dictionary.ContainsKey(key)) return dictionary[key];
            dictionary[key] = update;
            return update;
        }
    }
}
