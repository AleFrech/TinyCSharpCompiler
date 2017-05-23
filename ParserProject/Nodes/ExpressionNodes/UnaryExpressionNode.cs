using System;
namespace ParserProject.Nodes.ExpressionNodes
{
    public class UnaryExpressionNode:ExpressionNode
    {
        public string Value { get; set; }
    }

    public class SumUnaryExpressionNode:UnaryExpressionNode{
        public SumUnaryExpressionNode(string pvalue){
            Value = pvalue;
        }
    }

	public class SubUnaryExpressionNode : UnaryExpressionNode
	{
		public SubUnaryExpressionNode(string pvalue)
		{
			Value = pvalue;
		}
	}

	public class NotUnaryExpressionNode : UnaryExpressionNode
	{
		public NotUnaryExpressionNode(string pvalue)
		{
			Value = pvalue;
		}
	}

	public class ComplementUnaryExpressionNode : UnaryExpressionNode
	{
		public ComplementUnaryExpressionNode(string pvalue)
		{
			Value = pvalue;
		}
	}

	public class IncUnaryExpressionNode : UnaryExpressionNode
	{
		public IncUnaryExpressionNode(string pvalue)
		{
			Value = pvalue;
		}
	}

	public class DecUnaryExpressionNode : UnaryExpressionNode
	{
		public DecUnaryExpressionNode(string pvalue)
		{
			Value = pvalue;
		}
	}





}
