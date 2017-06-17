using System;
using ParserProject.Generation;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.Nodes.ExpressionNodes.BinaryOperators
{
    public class BitOrExpressionNode : BinaryOperatorNode
	{

        public BitOrExpressionNode(){
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
			OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, Boolean), Boolean);
        }

	    public override ExpressionCode GenerateCode()
	    {
	        var leftType = LeftOperand.EvaluateSemantic();
	        var rightType = RightOperand.EvaluateSemantic();
	        if (leftType == Boolean && rightType == Boolean)
	        {
	            var s = "function getBoolBitOrValue(a,b) {\n";
	            s += "const c= a | b;\nreturn c==0 ? false : true ;\n }\n\n ";
	            s += "getBoolBitOrValue(" + LeftOperand.GenerateCode().Code + ") , (" + RightOperand.GenerateCode().Code + ");\n";

	            return new ExpressionCode { Code = s };

	        }
	        if (leftType == Integer && rightType == Integer)
	        {
	            return new ExpressionCode { Code = "( " + LeftOperand.GenerateCode().Code + " & " + RightOperand.GenerateCode().Code + ")" };
	        }

	        var stringCode = "function decimalToBinary(decimal) {\n    return (decimal >>> 0).toString();\n}\n\n";
	        stringCode += "function getIntBitOrValue(c, i) {\n    const decC = typeof c === 'number' ? c : c.charCodeAt(0);\n    const decI = typeof i === 'number' ? i : i.charCodeAt(0);\n    const binC = decimalToBinary(decC);\n    const binI = decimalToBinary(decI);\n    return binC | binI;\n}\n\n";
	        stringCode = "getIntBitOrValue(" + LeftOperand.GenerateCode().Code + ") , (" + RightOperand.GenerateCode().Code + ");\n";

	        return new ExpressionCode { Code = stringCode };
	    }
    }
}
