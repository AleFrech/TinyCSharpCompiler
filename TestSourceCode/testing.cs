using LexerProject;
using LexerProject.Tokens;
using ParserProject.Exceptions;


namespace mierda.mierda
{
   using LexerProject;

   namespace tucu
   {
      using LexerProject;

      public class Mierda : IMierda,ITucu
      {
        
      }

      public interface IName:IMierda,System.ITest
      {
            string Name
            {
                private get;
                set;
            }

            int Counter
            {
                protected get;
            }

         bool Equals(T obj,int param);
         void MethodToImplement();
      }

      public enum tortas
      {
            DeZuma,
            DeZuHelma=2,
            DeZuTia=3
      }

   }
}