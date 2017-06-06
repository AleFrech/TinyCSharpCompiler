using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes;
using ParserProject.Nodes.NameSpaceNodes.MethodModiferNodes;
using ParserProject.Nodes.PrivacyModifierNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class FieldMemberDeclaration : ClassMemberDeclaration
    {
        public string PrivacyModifier { get; set; }
        public TypeExpressionNode Type { get; set; }
        public FieldMethodDeclarationNode FieldMethod { get; set; }
        public MethodModifierNode MethodModifer { get; set; }
        
    }
}