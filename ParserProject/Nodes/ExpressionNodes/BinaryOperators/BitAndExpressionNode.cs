using System;
using ParserProject.Generation;
using ParserProject.Nodes.ExpressionNodes.BinaryOperators;
using ParserProject.Semantic.CustomTypes;

namespace ParserProject.BinaryOperators.ExpressionNodes.Nodes
{
    public class BitAndExpressionNode : BinaryOperatorNode
    {
        public BitAndExpressionNode()
        {
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Integer), Integer); ;
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Integer), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Integer, Char), Integer);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Boolean, Boolean), Boolean);
            OperatorRules.Add(new Tuple<CustomType, CustomType>(Char, Char), Integer);
        }

        public override ExpressionCode GenerateCode()
        {
            var leftType = LeftOperand.EvaluateSemantic();
            var rightType = RightOperand.EvaluateSemantic();
            if (leftType == Boolean && rightType == Boolean)
            {
				var s = "function getBoolBitAndValue(a,b) {\n";
				s += "const c= a & b;\nreturn c==0 ? false : true ;\n }\n\n ";
                s += "getBoolBoolBitAndValue(" + LeftOperand.GenerateCode().Code + ") , (" + RightOperand.GenerateCode().Code + ");\n";
              
                return new ExpressionCode { Code = s };

            }
            if (leftType == Integer && rightType == Integer)
            {
                return new ExpressionCode { Code = "( " + LeftOperand.GenerateCode().Code + " & " + RightOperand.GenerateCode().Code + ")" };
            }

            var stringCode = "function decimalToBinary(decimal) {\n    return (decimal >>> 0).toString();\n}\n\n";
            stringCode += "function getIntBitAndValue(c, i) {\n    const decC = typeof c === 'number' ? c : c.charCodeAt(0);\n    const decI = typeof i === 'number' ? i : i.charCodeAt(0);\n    const binC = decimalToBinary(decC);\n    const binI = decimalToBinary(decI);\n    return binC & binI;\n}\n\n";
            stringCode = "getIntBitAndValue(" + LeftOperand.GenerateCode().Code + ") , (" + RightOperand.GenerateCode().Code + ");\n";
				
			return new ExpressionCode { Code = stringCode };
        }

    }
}
