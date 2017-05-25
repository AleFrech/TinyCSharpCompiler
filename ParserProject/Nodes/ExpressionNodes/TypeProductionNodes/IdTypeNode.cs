using System;
namespace ParserProject.Nodes.ExpressionNodes.TypeProductionNodes
{
    public class IdTypeNode:TypeProductionNode
    {
        public string Name { get; set; }
        public IdTypeNode IdType { get; set; }

        public IdTypeNode(string name, IdTypeNode idtype )
        {
            Name = name;
            IdType = idtype;
        }
    }
}
