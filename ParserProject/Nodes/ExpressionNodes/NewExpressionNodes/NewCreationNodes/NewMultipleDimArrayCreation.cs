using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes.ArrayNodes;

namespace ParserProject.Nodes.ExpressionNodes.NewExpressionNodes.NewCreationNodes
{
    public class NewMultipleDimArrayCreation: NewCreationExpressionNode
    {
        public List<DimSeparatorNode> DimSeparatorList { get; set; }
        public List<RankSpeciferNode> RankSpecifiers { get; set; }
        public ArrayInitalizerNode ArrayInitalizer { get; set; }
    }
}
