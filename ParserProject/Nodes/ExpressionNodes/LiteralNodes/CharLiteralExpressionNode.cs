using System;
namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class CharLiteralExpressionNode:LiteralNodeExpression
    {
        public char Value { get; set; }

        public CharLiteralExpressionNode(char @value)
        {
            Value = @value;
        }
    }
}
