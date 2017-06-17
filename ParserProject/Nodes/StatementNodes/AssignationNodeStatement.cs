using System;
using System.Collections.Generic;
using System.Text;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes;
using ParserProject.Semantic;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.StatementNodes
{
    public class AssignationNodeStatement:StatementNode
    {
        public Dictionary<Tuple<CustomType, CustomType>, CustomType> OperatorRules
            = new Dictionary<Tuple<CustomType, CustomType>, CustomType>();
        public ExpressionNode LeftValue { get; set; }
        public ExpressionNode RightValue { get; set; }
        public string IncOrDec { get; set; }
        public AssignationNodeStatement()
        {

        }

        public override void EvaluateSemantic()
        {

        }



		public override ExpressionCode GenerateCode()
		{
			return new ExpressionCode { Code = LeftValue.GenerateCode().Code };
		}
    }






}
