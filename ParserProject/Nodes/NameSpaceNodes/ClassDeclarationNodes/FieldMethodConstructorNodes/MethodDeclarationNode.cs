using System;
using System.Collections.Generic;
using System.Text;
using LexerProject.Tokens;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.StatementNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes.FieldMethodConstructorNodes
{
    public class MethodDeclarationNode:FieldMethodDeclarationNode
    {
        public Token Name { get; set; }
        public List<ParameterNode> ParameterList { get; set; }
        public List<StatementNode> StatementList { get; set; }
    }
}
