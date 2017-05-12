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
            return tokenType == TokenType.RwFloat || tokenType == TokenType.RwInt || tokenType == TokenType.RwString ||
                   tokenType == TokenType.RwBool;
        }

        public static bool IsMethodModifiers(this TokenType tokenType){
            return tokenType == TokenType.RwOverride || tokenType == TokenType.RwVirtual || tokenType == TokenType.RwAbstract;
        }
    }
}