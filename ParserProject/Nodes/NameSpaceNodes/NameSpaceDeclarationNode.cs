using System;
using ParserProject.Generation;

namespace ParserProject.Nodes.NameSpaceNodes
{
    public abstract class NameSpaceDeclarationNode
    {
        public NameSpaceDeclarationNode()
        {
        }

        public abstract ExpressionCode GenerateCode();
    }
}
