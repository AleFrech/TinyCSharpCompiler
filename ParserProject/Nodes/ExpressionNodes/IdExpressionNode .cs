using System;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.PreIdNodes;
using ParserProject.Nodes.ExpressionNodes.PostIdNodes;
using ParserProject.Nodes.ExpressionNodes.AssignationNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class IdExpressionNode: PrimaryExpressionNode
    {
        public IdLeftExpressionNode IdLeft { get; set; }

        public AssignationExpressionNode AssignmentNode { get; set; }
        public PostIdExpressionNode PostId { get; set; }

        public IdExpressionNode(IdLeftExpressionNode idLeft, AssignationExpressionNode assgnNode,PostIdExpressionNode postId)
        {
            PostId = postId;
            AssignmentNode = assgnNode;
            IdLeft = idLeft;
        }
    }

    public class IdLeftExpressionNode : PrimaryExpressionNode
    {
        public PreIdExpressionNode PreId { get; set; }
        public string Name { get; set; }
        public AccesorExpressionNode Accessor { get; set; }


        public IdLeftExpressionNode(PreIdExpressionNode preId, string name,AccesorExpressionNode accesor)
        {
            PreId = preId;
            Name = name;
            Accessor = accesor;
        }

    }

}
