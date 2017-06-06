using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes.FieldMethodConstructorNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes
{
    public class ClassNode : NameSpaceDeclarationNode
    {
        public string PrivacyModifier { get; set; }
        public string ClassModifier { get; set; }
        public Token NameToken { get; set; }
        public List<IdTypeNode> HeritageList { get; set; }

        public List<FieldMethodConstructor> FieldMethodConstructorList { get; set; }
    }
}
