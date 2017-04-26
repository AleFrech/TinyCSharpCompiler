namespace LexerProject.Token
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Lexeme { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }

        public override string ToString()
        {
            return "Lexeme: " + Lexeme + " Type: " + Type +" Line: "+Line+" Column "+Column;
        }
    }
}