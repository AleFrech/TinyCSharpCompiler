using System;
namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class FloatLiteralExpressionNode:LiteralNodeExpression
    {
        public float Value { get; set; }

        public FloatLiteralExpressionNode(float @value)
        {
            Value = @value;
        }
    }
}
