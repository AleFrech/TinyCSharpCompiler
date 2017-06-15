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
            throw new NotImplementedException();
        }

		public override ExpressionCode GenerateCode()
		{
            var helper = new GenerationHelper();
            var stringCode = "";
            stringCode += IdNode.PreId;
            stringCode += helper.GetFullNameFromIdNode(IdNode.Id);
            stringCode += helper.GetFullAccessorFromAccessorNode(IdNode.Accessor);
            if (AssignmentNode != null)
                stringCode += AssignmentNode.GenerateCode();
            stringCode += PostId;


            return new ExpressionCode { Code = stringCode };
		}


    }
}
