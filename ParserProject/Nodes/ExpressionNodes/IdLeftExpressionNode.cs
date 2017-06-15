using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class IdLeftExpressionNode : PrimaryExpressionNode
    {
        public string PreId { get; set; }
        public IdTypeNode Id { get; set; }
        public AccesorExpressionNode Accessor { get; set; }


        public IdLeftExpressionNode(string preId, IdTypeNode name,AccesorExpressionNode accesor)
        {
            PreId = preId;
            Id = name;
            Accessor = accesor;
        }

        public IdLeftExpressionNode(){
            
        }

		public override ExpressionCode GenerateCode()
		{
			var helper = new GenerationHelper();
			var stringCode = "";
			stringCode += PreId;
			stringCode += helper.GetFullNameFromIdNode(Id);
            stringCode += Accessor.GenerateCode().Code;

			return new ExpressionCode { Code = stringCode };
		}


	}
}