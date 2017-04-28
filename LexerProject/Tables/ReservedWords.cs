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

                {"as",TokenType.RwAs},
                { "abstract", TokenType.RwAbstract},
                { "break", TokenType.RwBreak },
                { "bool", TokenType.RwBool},
                { "char", TokenType.RwChar },
                { "case", TokenType.RwCase },
                { "catch", TokenType.RwCatch},
                { "class", TokenType.RwClass},
                { "const", TokenType.RwConst},
                { "continue", TokenType.RwContinue},
                { "default", TokenType.RwDefault },
                { "do", TokenType.RwDo },
                { "date", TokenType.LitDate},
                { "else", TokenType.RwElse },
                { "enum", TokenType.RwEnum },
                { "false", TokenType.LitBool },
                { "float", TokenType.RwFloat },
                { "for", TokenType.RwFor },
                { "foreach", TokenType.RwForeach },
                { "if", TokenType.RwIf },
                { "int", TokenType.RwInt},
                { "interface", TokenType.RwInterface},
                { "internal", TokenType.RwInternal},
                { "is", TokenType.RwIs},
                { "long", TokenType.RwLong },
                { "namespace", TokenType.RwNamespace},
                { "new", TokenType.RwNew},
                { "null", TokenType.RwNull},
                { "object", TokenType.RwObject},
                { "private", TokenType.RwPrivate},
                { "protected", TokenType.RwProtected},
                { "public", TokenType.RwPublic},
                { "return", TokenType.RwReturn },
                { "sizeof", TokenType.RwSizeof },
                { "static", TokenType.RwStatic},
                { "string",TokenType.RwString},
                { "switch", TokenType.RwSwitch },
                { "true", TokenType.LitBool },
                { "this", TokenType.RwThis },
                { "typeof", TokenType.RwTypeof },
                { "using", TokenType.RwUsing },
                { "virtual", TokenType.RwVirtual },
                { "void", TokenType.RwVoid },
                { "var", TokenType.RwVar },
                { "try", TokenType.RwTry },
                {"finally",TokenType.RwFinally},
                { "while", TokenType.RwWhile },
            };

        }
    }
}