using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Nodes.ExpressionNodes.TypeProductionNodes;

namespace ParserProject.Nodes.StatementNodes.DeclarationAsignationStatementNodes
{
    public class DeclarationNodeStatement :DeclarationAsignationStatement
    {
        public TypeExpressionNode Type { get; set; }
        public List<DeclaratorNode> DeclarationList { get; set; }
    }
}
