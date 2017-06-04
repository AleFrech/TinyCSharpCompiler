using System;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public abstract class StatementNode
    {
        public CustomType Integer = TypesTable.Instance.GetType("Int");
        public CustomType String = TypesTable.Instance.GetType("String");
        public CustomType Boolean = TypesTable.Instance.GetType("Bool");
        public CustomType Char = TypesTable.Instance.GetType("Char");
        public CustomType Float = TypesTable.Instance.GetType("Float");
        public CustomType Enum = TypesTable.Instance.GetType("Enum");
        public CustomType Void = TypesTable.Instance.GetType("Void");
        public StatementNode()
        {

        }

        public abstract CustomType EvaluateSemantic();
    }
}
