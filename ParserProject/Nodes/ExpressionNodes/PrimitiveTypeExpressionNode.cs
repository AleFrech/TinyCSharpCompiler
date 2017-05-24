using System;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.PostIdNodes;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class PrimitiveTypeExpressionNode:ExpressionNode
    {
        public PrimitiveTypeNode PrimitiveType { get; set; }
        public string Name { get; set; }
        public AccesorExpressionNode Accessor { get; set; }
        public PostIdExpressionNode PostId { get; set; }

        public PrimitiveTypeExpressionNode(PrimitiveTypeNode primitiveType,string name,AccesorExpressionNode accessor,PostIdExpressionNode posId)
        {
            PrimitiveType = primitiveType;
            Name = name;
            Accessor = accessor;
            PostId = posId;
        }
    }
}
