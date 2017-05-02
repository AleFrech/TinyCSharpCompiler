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
                {"byte",TokenType.RwByte},
                {"case",TokenType.RwCase},
                {"catch",TokenType.RwCatch},
                {"char",TokenType.RwChar},
                {"checked",TokenType.RwChecked},
                {"class",TokenType.RwClass},
                {"const",TokenType.RwConst},
                {"continue",TokenType.RwContinue},
                {"decimal",TokenType.RwDecimal},
                {"default",TokenType.RwDefault},
                {"delegate",TokenType.RwDelegate},
                {"do",TokenType.RwDo},
                {"double",TokenType.RwDouble},
                {"else",TokenType.RwElse},
                {"enum",TokenType.RwEnum},
                {"event",TokenType.RwEvent},
                {"explicit",TokenType.RwExplicit},
                {"extern",TokenType.RwExtern},
                {"false",TokenType.RwFalse},
                {"finally",TokenType.RwFinally},
                {"fixed",TokenType.RwFixed},
                {"float",TokenType.RwFloat},
                {"for",TokenType.RwFor},
                {"foreach",TokenType.RwForeach},
                {"goto",TokenType.RwGoto},
                {"if",TokenType.RwIf},
                {"implicit",TokenType.RwImplicit},
                {"in",TokenType.RwIn},
                {"int",TokenType.RwInt},
                {"interface",TokenType.RwInterface},
                {"internal",TokenType.RwInternal},
                {"is",TokenType.RwIs},
                {"lock",TokenType.RwLock},
                {"long",TokenType.RwLong},
                {"namespace",TokenType.RwNamespace},
                {"new",TokenType.RwNew},
                {"null",TokenType.RwNull},
                {"object",TokenType.RwObject},
                {"operator",TokenType.RwOperator},
                {"out",TokenType.RwOut},
                {"override",TokenType.RwOverride},
                {"params",TokenType.RwParams},
                {"private",TokenType.RwPrivate},
                {"protected",TokenType.RwProtected},
                {"public",TokenType.RwPublic},
                {"readonly",TokenType.RwReadonly},
                {"ref",TokenType.RwRef},
                {"return",TokenType.RwReturn},
                {"sbyte",TokenType.RwSbyte},
                {"sealed",TokenType.RwSealed},
                {"short",TokenType.RwShort},
                {"sizeof",TokenType.RwSizeof},
                {"static",TokenType.RwStatic},
                {"string",TokenType.RwString},
                {"struct",TokenType.RwStruct},
                {"switch",TokenType.RwSwitch},
                {"this",TokenType.RwThis},
                {"throw",TokenType.RwThrow},
                {"true",TokenType.RwTrue},
                {"try",TokenType.RwTry},
                {"typeof",TokenType.RwTypeof},
                {"uint",TokenType.RwUint},
                {"ulong",TokenType.RwUlong},
                {"unchecked",TokenType.RwUnchecked},
                {"unsafe",TokenType.RwUnsafe},
                {"ushort",TokenType.RwUshort},
                {"using",TokenType.RwUsing},
                {"virtual",TokenType.RwVirtual},
                {"volatile",TokenType.RwVolatile},
                {"void",TokenType.RwVoid},
                {"while",TokenType.RwWhile},
                {"var",TokenType.RwVar}
            };

        }
    }
}