using System.Net;
using LexerProject.Tokens;

namespace ParserProject.Extensions
{
    public static class TokenTypeExtensions
    {

        public static bool IsNameSpace(this TokenType tokenType)
        {
            return (tokenType == TokenType.RwUsing || tokenType.IsPrivacyModifier() ||
                    tokenType == TokenType.RwAbstract || tokenType == TokenType.RwStatic
                    || tokenType == TokenType.RwInterface || tokenType == TokenType.RwEnum || tokenType==TokenType.RwNamespace);
        }

        public static bool IsPrivacyModifier(this TokenType tokenType)
        {
            return tokenType == TokenType.RwPrivate || tokenType == TokenType.RwPublic ||
                   tokenType == TokenType.RwProtected;
        }

        public static bool IsClassModifier(this TokenType tokenType)
        {
            return tokenType == TokenType.RwAbstract || tokenType == TokenType.RwStatic;
        }

        public static bool IsType(this TokenType tokenType)
        {
            return tokenType == TokenType.Id || tokenType.IsPredifinedType() || tokenType == TokenType.RwEnum;
        }

        public static bool IsPredifinedType(this TokenType tokenType)
        {
            return tokenType == TokenType.RwFloat || tokenType == TokenType.RwInt || tokenType == TokenType.RwString || tokenType ==TokenType.RwChar ||
                   tokenType == TokenType.RwBool;
        }

        public static bool IsMethodModifiers(this TokenType tokenType){
            return tokenType == TokenType.RwOverride || tokenType == TokenType.RwVirtual || tokenType == TokenType.RwAbstract;
        }

        public static bool IsStatements(this TokenType tokenType){
            return (tokenType == TokenType.RwIf || tokenType == TokenType.RwWhile || tokenType == TokenType.RwDo || tokenType == TokenType.RwSwitch ||
                tokenType == TokenType.RwFor || tokenType == TokenType.RwForeach || tokenType==TokenType.RwReturn || tokenType==TokenType.RwBreak ||
                    tokenType == TokenType.RwContinue || tokenType==TokenType.EndStatement || tokenType==TokenType.RwVar || IsType(tokenType)
                    || tokenType == TokenType.OpDec || tokenType == TokenType.OpInc || tokenType == TokenType.RwBase || tokenType == TokenType.RwThis);
        }

		public static bool IsExpression(this TokenType tokenType)
		{
            return IsLiteral(tokenType);
		}

		public static bool IsUnaryExpression(this TokenType tokenType)
		{
            return tokenType == TokenType.OpSum || tokenType == TokenType.OpSub || tokenType == TokenType.OpInc || tokenType == TokenType.OpDec ||
                                         tokenType == TokenType.OpBinaryComplement || tokenType==TokenType.OpLogicalNot;
		}

		public static bool IsLiteral(this TokenType tokenType)
		{
            return tokenType == TokenType.LitNum || tokenType == TokenType.LitChar || tokenType == TokenType.LitString || tokenType == TokenType.LitFloat ||
                                         tokenType == TokenType.LitBool;
		}

		public static bool IsPrimaryNoArrayCreationExpression(this TokenType tokenType)
		{
			return IsLiteral(tokenType);
		}

        public static bool IsAssignationOperator(this TokenType tokenType)
        {
            return tokenType == TokenType.OpAsgn || tokenType == TokenType.OpAddAsgn ||
                   tokenType == TokenType.OpSubAsgn || tokenType == TokenType.OpMulAsgn ||
                   tokenType == TokenType.OpDivAsgn || tokenType == TokenType.OpModAsgn ||
                   tokenType == TokenType.OpAndAsgn || tokenType == TokenType.OpOrAsgn ||
                   tokenType == TokenType.OpXorAsgn || tokenType == TokenType.OpLftShftAsgn ||
                   tokenType == TokenType.OpRghtShftAsgn;
        }
    }

}