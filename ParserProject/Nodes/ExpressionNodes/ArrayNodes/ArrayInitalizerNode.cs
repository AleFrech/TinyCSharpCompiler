﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ParserProject.Nodes.ExpressionNodes.ArrayNodes
{
    public class ArrayInitalizerNode:ExpressionNode
    {
        public List<ExpressionNode> ExpressionList { get; set; }
    }
}
