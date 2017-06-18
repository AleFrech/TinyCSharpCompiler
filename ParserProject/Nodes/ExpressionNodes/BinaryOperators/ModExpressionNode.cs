using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class ModExpressionNode : BinaryOperatorNode
	{

        public ModExpressionNode(){
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);

            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);

			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Float), Float);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Float), Float);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Integer), Float);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Float), Float);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Float, Char), Float);
        }

	    public override ExpressionCode GenerateCode()
	    {
	        throw new NotImplementedException();
	    }
	}

}
