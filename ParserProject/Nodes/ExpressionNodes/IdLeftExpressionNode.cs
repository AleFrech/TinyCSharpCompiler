using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Semantic;

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
            var idName=helper.GetFullNameFromIdNode(Id);
			var stringCode = "";
			stringCode += PreId;
            stringCode += idName;
            stringCode += Accessor.GenerateCode().Code;
            var type = "string";
			if (SymbolTable.vars.ContainsKey(idName))
			{
				type = SymbolTable.vars[idName];
			}
            return new ExpressionCode { Code = stringCode,Type=type };
		}


	}
}