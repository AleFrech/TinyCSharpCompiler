using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public class StaticFieldMemberDeclaration :ClassMemberDeclaration
    {
        public TypeExpressionNode Type { get; set; }
        public FieldMethodDeclarationNode FieldMethod { get; set; }
    }
}
