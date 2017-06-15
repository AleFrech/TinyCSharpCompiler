using System;
using ParserProject.Generation;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public abstract class StatementNode
    {
        public CustomType Integer = CustomTypesTable.Instance.GetType("Int");
        public CustomType String = CustomTypesTable.Instance.GetType("String");
        public CustomType Boolean = CustomTypesTable.Instance.GetType("Bool");
        public CustomType Char = CustomTypesTable.Instance.GetType("Char");
        public CustomType Float = CustomTypesTable.Instance.GetType("Float");
        public CustomType Enum = CustomTypesTable.Instance.GetType("Enum");
        public CustomType Void = CustomTypesTable.Instance.GetType("Void");
        public StatementNode()
        {

        }

        public abstract void EvaluateSemantic();

		public abstract ExpressionCode GenerateCode();

	}
}
