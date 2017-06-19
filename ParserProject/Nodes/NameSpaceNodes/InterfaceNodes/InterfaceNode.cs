using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.NameSpaceNodes.InterfaceNodes
{
    public class InterfaceNode:NameSpaceDeclarationNode
    {
        public string PrivacyModifier { get; set; }
        public Token NameToken { get; set; }
        public List<IdTypeNode> HeritageList { get; set; }

        public List<InterfaceMethodNode> InterfaceMethodList { get; set; }

        public override ExpressionCode GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
