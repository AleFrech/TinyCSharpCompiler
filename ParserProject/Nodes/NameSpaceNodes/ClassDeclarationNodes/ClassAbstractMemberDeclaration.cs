using System.Collections.Generic;
using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.PrivacyModifierNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes
{
    public class ClassAbstractMemberDeclaration : ClassMemberDeclaration
    {
        public string PrivacyModifier { get; set; }
        public TypeExpressionNode TypeNode { get; set; }
        public Token NameToken { get; set; }
        public List<ParameterNode> ParameterList { get; set; }
       
    }
}
