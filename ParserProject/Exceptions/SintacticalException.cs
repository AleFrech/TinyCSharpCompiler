using System;


namespace ParserProject.Exceptions
{
    public class SintacticalException:Exception
    {
        public SintacticalException(string message) : base(message)
        {

        }
    }

    public class NameSpaceNotFoundExcpetion : Exception
    {
        public NameSpaceNotFoundExcpetion(string message) : base(message)
        {

        }
    }

    public class ClassNotFoundExcpetion : Exception
    {
        public ClassNotFoundExcpetion(string message) : base(message)
        {

        }
    }
}
