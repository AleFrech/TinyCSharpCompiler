using System;
namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class IntLiteralExpressionNode:LiteralNodeExpression
    {
        public int Value { get; set; }

        public IntLiteralExpressionNode(int @value)
        {
            Value = @value;
        }
    }
}
