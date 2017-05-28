using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes;
using ParserProject.Nodes.PrivacyModifierNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class StaticFieldMemberDeclaration :ClassMemberDeclaration
    {
        public PrivacyModifierNode PrivacyModifie { get; set; }
        public TypeExpressionNode Type { get; set; }
        public FieldMethodDeclarationNode FieldMethod { get; set; }
      
    }
}
