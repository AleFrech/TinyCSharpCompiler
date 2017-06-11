using System;
using ParserProject.Nodes.ExpressionNodes.AssignationNodes;
using ParserProject.Nodes.ExpressionNodes.PostIdNodes;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class IdExpressionNode : PrimaryExpressionNode
    {
        public IdLeftExpressionNode IdNode { get; set; }

        public AssignationExpressionNode AssignmentNode { get; set; }
        public PostIdExpressionNode PostId { get; set; }

        public IdExpressionNode(IdLeftExpressionNode idLeft, AssignationExpressionNode assgnNode, PostIdExpressionNode postId)
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
    }
}
