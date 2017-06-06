using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes;
using ParserProject.Nodes.PrivacyModifierNodes;
using ParserProject.Nodes.StatementNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class ConstructorNode : ClassMemberDeclaration
    {
        public string PrivacyModifier { get; set; }
        public IdTypeProductionNode Type { get; set; }
        public List<ParameterNode> ParameterList { get; set; }
        public List<StatementNode> StatementList { get; set; }
        public ConstructorInitalizerNode ConstructorInitalizer { get; set; }
    }
}