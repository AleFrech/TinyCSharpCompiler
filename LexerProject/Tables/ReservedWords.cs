using System.Collections.Generic;
using LexerProject.Tokens;

namespace LexerProject.Tables
{
    public class ReservedWords
    {
        public readonly Dictionary<string, TokenType> Collection;

        public ReservedWords()
        {
            Collection = new Dictionary<string, TokenType>
            {
                {"abstract",TokenType.RwAbstract},
                {"as",TokenType.RwAs},
                {"base",TokenType.RwBase},
                {"bool",TokenType.RwBool},
                {"break",TokenType.RwBreak},
                {"case",TokenType.RwCase},
                {"catch",TokenType.RwCatch},
                {"char",TokenType.RwChar},
                {"class",TokenType.RwClass},
                {"const",TokenType.RwConst},
                {"continue",TokenType.RwContinue},
                {"default",TokenType.RwDefault},
                {"do",TokenType.RwDo},
                {"else",TokenType.RwElse},
                {"enum",TokenType.RwEnum},
                {"false",TokenType.LitBool},
                {"finally",TokenType.RwFinally},
                {"float",TokenType.RwFloat},
                {"for",TokenType.RwFor},
                {"foreach",TokenType.RwForeach},
                {"if",TokenType.RwIf},
                {"in",TokenType.RwIn},
                {"int",TokenType.RwInt},
                {"interface",TokenType.RwInterface},
                {"internal",TokenType.RwInternal},
                {"is",TokenType.RwIs},
                {"namespace",TokenType.RwNamespace},
                {"new",TokenType.RwNew},
                {"null",TokenType.RwNull},
                {"override",TokenType.RwOverride},
                {"private",TokenType.RwPrivate},
                {"protected",TokenType.RwProtected},
                {"public",TokenType.RwPublic},
                {"return",TokenType.RwReturn},
                {"sizeof",TokenType.RwSizeof},
                {"static",TokenType.RwStatic},
                {"string",TokenType.RwString},
                {"switch",TokenType.RwSwitch},
                {"this",TokenType.RwThis},
                {"throw",TokenType.RwThrow},
                {"true",TokenType.LitBool},
                {"try",TokenType.RwTry},
                {"typeof",TokenType.RwTypeof},
                {"using",TokenType.RwUsing},
                {"virtual",TokenType.RwVirtual},
                {"void",TokenType.RwVoid},
                {"while",TokenType.RwWhile},
                {"var",TokenType.RwVar},
            };

        }
    }
}