﻿using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationXorExpressionNode : AssignationExpressionNode
	{
		public AssignationXorExpressionNode(IdExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}
	}
}