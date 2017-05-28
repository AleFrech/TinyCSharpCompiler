using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes;
using ParserProject.Nodes.StatementNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class ConstructorNode : ClassMemberDeclaration
    {
        public IdTypeProductionNode Type { get; set; }
        public List<StatementNode> StatementList { get; set; }
        public ConstructorInitalizerNode ConstructorInitalizer { get; set; }
    }
}