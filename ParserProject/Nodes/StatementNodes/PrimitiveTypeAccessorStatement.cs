using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;

namespace ParserProject.Nodes.StatementNodes
{
    public class PrimitiveTypeAccessorStatement:StatementNode
    {
        public PrimitiveTypeNode Type { get; set; }
        public Token Name { get; set; }
        public AccesorExpressionNode Accesor { get; set; }
        public string PostId { get;  set; }

        public override void EvaluateSemantic()
        {
            throw new System.NotImplementedException();
        }

		public override ExpressionCode GenerateCode()
		{
			var helper = new GenerationHelper();
			var stringCode = "";
			stringCode += Type.GenerateCode().Code + ".";
            stringCode += Name.Lexeme;
            stringCode += Accesor.GenerateCode().Code;
			stringCode += PostId;


			return new ExpressionCode { Code = stringCode };
		}
    }
}
