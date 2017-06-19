using System;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class NameSpaceNode:NameSpaceDeclarationNode
    {
        public IdTypeNode IdNode { get; set; }
        public CodeNode Code { get; set; }
        public NameSpaceNode()
        {
        }

        public override ExpressionCode GenerateCode()
		{
			var helper = new GenerationHelper();
			var namespaceName = helper.GetFullNameFromIdNode(IdNode);
            return new ExpressionCode { Code = Code.GenerateCode().Code };
		}


    }
}
