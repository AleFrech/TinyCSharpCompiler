using System.Collections.Generic;

namespace LexerProject.Tables
{
    public class ReservedChars
    {
        public List<string> Collection;
        public ReservedChars()
        {
            Collection = new List<string>
            {
                "\\a",
                "\\b",
                "\\0",
                "\\f",
                "\\n",
                "\\r",
                "\\t",
                "\\v",
                "\\\\",
                "\\\"",
                "\\?",
                "\\'",
            };
        }
    }
}
