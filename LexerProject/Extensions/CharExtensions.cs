namespace LexerProject.Extensions
{
    public static class CharExtensions
    {
        public static bool IsWhiteSpace(this char chr)
        {
            return char.IsWhiteSpace(chr);
        }

        public static bool IsDigit(this char chr)
        {
            return char.IsDigit(chr);
        }

        public static bool IsLetter(this char chr)
        {
            return char.IsLetter(chr);
        }

        public static bool IsLetterOrUnderscore(this char chr)
        {
            return char.IsLetter(chr) || chr.Equals('_') ;
        }

        public static bool IsLetterOrDigitOrUnderscore(this char chr)
        {
            return char.IsLetterOrDigit(chr) || chr.Equals('_');
        }

        public static bool IsEof(this char chr)
        {
            return chr.Equals('\0');
        }

        public static bool IsDoubleQuotes(this char chr)
        {
            return chr.Equals('"');
        }

        public static bool IsSingleQuotes(this char chr)
        {
            return chr.Equals('\'');
        }


        public static bool IsEnter(this char chr)
        {
            return chr.Equals('\r') || chr.Equals('\n');
        }

        public static bool IsHexValidLetter(this char chr)
        {
            return chr.Equals('a') || chr.Equals('A') || chr.Equals('b') || chr.Equals('B') || chr.Equals('c') || chr.Equals('C') || chr.Equals('d') || chr.Equals('D')
                   || chr.Equals('e') || chr.Equals('E') || chr.Equals('f') || chr.Equals('F');
        }

        public static bool IsHexValidNumber(this char chr)
        {

            return chr.Equals('0') || chr.Equals('1') || chr.Equals('2') || chr.Equals('3') || chr.Equals('4') || chr.Equals('5') || chr.Equals('6') || chr.Equals('7')
                   || chr.Equals('8') || chr.Equals('9');
        }
    }
}