using System;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.PreIdNodes;
using ParserProject.Nodes.ExpressionNodes.PostIdNodes;
using ParserProject.Nodes.ExpressionNodes.AssignationNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class IdExpressionNode: ExpressionNode
    {
        public PreIdExpressionNode PreId { get; set; }
        public string Name { get; set; }
        public AccesorExpressionNode Accessor { get; set; }
        public AssignationExpressionNode AssignmentNode { get; set; }
        public PostIdExpressionNode PostId { get; set; }

        public IdExpressionNode(PreIdExpressionNode preId,string name,AccesorExpressionNode accessor,AssignationExpressionNode assgnNode,PostIdExpressionNode postId)
        {
            PreId = preId;
            Name = name;
            Accessor = accessor;
            PostId = postId;
            AssignmentNode = assgnNode;
        }
    }
}
