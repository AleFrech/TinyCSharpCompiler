﻿using System;
namespace ParserProject.Nodes.ExpressionNodes.AssignationNodes
{
	public class AssignationLftShftExpressionNode : AssignationExpressionNode
	{
		public AssignationLftShftExpressionNode(IdExpressionNode left, ExpressionNode right)
		{
			LeftValue = left;
			RightValue = right;
		}
	}
}