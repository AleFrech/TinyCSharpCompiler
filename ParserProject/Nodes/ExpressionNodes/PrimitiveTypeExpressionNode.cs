using System;
using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes.AccesorNodes;
using ParserProject.Nodes.ExpressionNodes.PostIdNodes;
using ParserProject.Nodes.ExpressionNodes.PrimitiveTypeNodes;

namespace ParserProject.Nodes.ExpressionNodes
{
    public class PrimitiveTypeExpressionNode:PrimaryExpressionNode
    {
        public PrimitiveTypeNode PrimitiveType { get; set; }
        public Token Name { get; set; }
        public AccesorExpressionNode Accessor { get; set; }
        public PostIdExpressionNode PostId { get; set; }

        public PrimitiveTypeExpressionNode(PrimitiveTypeNode primitiveType,Token name,AccesorExpressionNode accessor,PostIdExpressionNode posId)
        {
            PrimitiveType = primitiveType;
            Name = name;
            Accessor = accessor;
            PostId = posId;
        }

        public PrimitiveTypeExpressionNode(){
            
        }
    }
}
