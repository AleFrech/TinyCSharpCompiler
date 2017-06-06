using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;

namespace ParserProject.Nodes.NameSpaceNodes.EnumNodes
{
    public class EnumNode:NameSpaceDeclarationNode
    {
        public string PrivacyModifier { get; set; }
        public Token NameToken { get; set; }

        public List<EnumElementNode> EnumElementList { get; set; }
    }
}
