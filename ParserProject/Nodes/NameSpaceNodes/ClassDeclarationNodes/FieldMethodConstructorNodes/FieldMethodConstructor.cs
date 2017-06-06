using System.Collections.Generic;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;
using ParserProject.Nodes.StatementNodes;

namespace ParserProject.Nodes.NameSpaceNodes.ClassDeclarationNodes.FieldMethodConstructorNodes
{
    public  class FieldMethodConstructor
    {
        public bool IsStatic { get; set; }
        public bool IsMethod { get; set; }
        public bool IsField { get; set; }
        public bool IsConstructor { get; set; }
        public string PrivacyModifier { get;  set; }
        public string MethodModifier { get; set; }
        public TypeExpressionNode Type { get; set; }
		public List<FieldNode> FieldList { get; set; }
		public MethodDeclarationNode Method { get; set; }
        public List<ParameterNode> ConstructorParameterList { get; set; }
        public BaseConstructorNode BaseNode { get; set; }
        public List<StatementNode> ConstructorStatementList { get; set; }
    }
}