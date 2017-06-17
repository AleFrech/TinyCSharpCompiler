using System;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.AssignationNodes;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class IdExpressionNode : PrimaryExpressionNode
    {
        public IdLeftExpressionNode IdNode { get; set; }

        public AssignationExpressionNode AssignmentNode { get; set; }
        public string PostId { get; set; }

        public IdExpressionNode(IdLeftExpressionNode idLeft, AssignationExpressionNode assgnNode, string postId)
        {
            PostId = postId;
            AssignmentNode = assgnNode;
            IdNode = idLeft;
        }

        public IdExpressionNode()
        {

        }

        public override CustomType EvaluateSemantic()
        {
            return null;
        }

		public override ExpressionCode GenerateCode()
		{
            var helper = new GenerationHelper();
            var stringCode = "";
            stringCode += IdNode.GenerateCode().Code;
            stringCode += AssignmentNode.GenerateCode().Code;
            stringCode += PostId;

            return new ExpressionCode { Code = stringCode };
		}


    }
}
