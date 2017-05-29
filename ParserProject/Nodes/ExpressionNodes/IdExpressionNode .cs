using System;
using ParserProject.Nodes.ExpressionNodes.AssignationNodes;
using ParserProject.Nodes.ExpressionNodes.PostIdNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class IdExpressionNode: PrimaryExpressionNode
    {
        public IdLeftExpressionNode Id { get; set; }

        public AssignationExpressionNode AssignmentNode { get; set; }
        public PostIdExpressionNode PostId { get; set; }

        public IdExpressionNode(IdLeftExpressionNode idLeft, AssignationExpressionNode assgnNode,PostIdExpressionNode postId)
        {
            PostId = postId;
            AssignmentNode = assgnNode;
            Id = idLeft;
        }

        public IdExpressionNode(){
            
        }
    }
}
