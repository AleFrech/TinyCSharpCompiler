using System;
namespace ParserProject.Nodes.ExpressionNodes.LiteralNodes
{
    public class StringLiteralExpressionNode:LiteralNodeExpression
    {
        public string Value { get; set; }

        public StringLiteralExpressionNode(string @value)
        {
            Value = @value;
        }

        public StringLiteralExpressionNode(){
            
        }
    }
}
