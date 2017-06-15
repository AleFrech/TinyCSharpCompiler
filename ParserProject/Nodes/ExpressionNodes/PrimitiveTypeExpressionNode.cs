using System;
using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class PrimitiveTypeExpressionNode:PrimaryExpressionNode
    {
        public PrimitiveTypeNode PrimitiveType { get; set; }
        public Token IdToken { get; set; }
        public AccesorExpressionNode Accessor { get; set; }
        public string PostId { get; set; }

        public PrimitiveTypeExpressionNode(PrimitiveTypeNode primitiveType,Token name,AccesorExpressionNode accessor,string posId)
        {
            PrimitiveType = primitiveType;
            IdToken = name;
            Accessor = accessor;
            PostId = posId;
        }

        public PrimitiveTypeExpressionNode(){
            
        }

		public override ExpressionCode GenerateCode()
		{
			var helper = new GenerationHelper();
			var stringCode = "";
            stringCode += PrimitiveType.GenerateCode().Code+".";
            stringCode += IdToken.Lexeme;
            stringCode += Accessor.GenerateCode().Code;
			stringCode += PostId;


			return new ExpressionCode { Code = stringCode };
		}

    }
}
