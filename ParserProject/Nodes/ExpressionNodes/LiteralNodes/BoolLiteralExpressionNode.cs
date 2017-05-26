using System;
namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class BoolLiteralExpressionNode:LiteralNodeExpression
    {
        public bool Value { get; set; }
        public BoolLiteralExpressionNode(bool @value)
        {
            Value = @value;
        }

        public BoolLiteralExpressionNode(){
            
        }
    }
}
