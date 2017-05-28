using System;
using System.Collections.Generic;
using System.Text;

namespace ParserProject.Nodes.ExpressionNodes.NewExpressionNodes.NewCreationNodes
{
    public class NewObjectCreation:NewCreationExpressionNode
    {
        public List<ExpressionNode> ObjectCollectionInitalizer { get; set; }

        public List<ExpressionNode> ObjectArgumentsList { get; set; }
    }

    public class NewArrayCreation : NewCreationExpressionNode
    {
        public List<ExpressionNode> ExpressionList { get; set; }
        public List<RankSpeciferNode> RankSpecifiers { get; set; }
        public ArrayInitalizerNode ArrayInitalizer { get; set; }
    }
}
