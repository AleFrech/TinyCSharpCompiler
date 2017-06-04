using System;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class BreakNodeStatement:StatementNode
    {
        public BreakNodeStatement()
        {
        }

        public override CustomType EvaluateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
