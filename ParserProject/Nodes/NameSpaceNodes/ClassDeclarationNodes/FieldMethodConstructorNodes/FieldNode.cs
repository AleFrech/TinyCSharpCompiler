using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes.FieldMethodConstructorNodes
{
    public class FieldNode
    {
        public Token Name { get; set; }
        public ExpressionNode ExpressionNode { get; set; }

		public ExpressionCode GenerateCode(string type)
		{
            var stringCode = "this."+Name.Lexeme;
            if (ExpressionNode!=null)
			{
                stringCode += " : ";
                stringCode += ExpressionNode.GenerateCode().Code;

            }else{
                stringCode += " : ";
                if (type == "int")
                    stringCode +="0";
                else if (type == "bool")
                    stringCode += "false";
				else if (type == "float")
					stringCode +="0.0";
				else if (type == "char")
					stringCode += @"'\0'";
                else
                    stringCode += "null";
            }

            stringCode += ";";
            return new ExpressionCode { Code = stringCode };
		}


    }
}
