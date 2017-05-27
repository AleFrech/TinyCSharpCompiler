using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.PrivacyModifierNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes
{
    public class ClassAbstractMemberDeclaration : ClassMemberDeclaration
    {
        public PrivacyModifierNode PrivacyNode { get; set; }
        public TypeExpressionNode TypeNode { get; set; }
        public string Name { get; set; }
        public List<ParameterNode> ParameterList { get; set; }
    }
}
