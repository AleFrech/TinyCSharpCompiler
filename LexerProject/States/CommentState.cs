using LexerProject.Exceptions;
using LexerProject.Extensions;

namespace LexerProject.States
{
    public class CommentState
    {

        public void ConsumeComments(ref Symbol currentSymbol,InputString inputString)
        {
            if(currentSymbol.Character.Equals('/')){
                currentSymbol = inputString.GetNextSymbol();
                if (currentSymbol.Character.Equals('/'))
                {
                    currentSymbol = inputString.GetNextSymbol();
                    while (true)
                    {
                        if (currentSymbol.Character.Equals('\r') || currentSymbol.Character.Equals('\n') ||
                            currentSymbol.Character.IsEof())
                            break;
                        currentSymbol = inputString.GetNextSymbol();
                    }


                }
                else if (currentSymbol.Character.Equals('*'))
                {
                    while (true)
                    {
                        if (currentSymbol.Character.IsEof())
                            throw new LexicalException(" Opened Comment Section  Line: " + currentSymbol.Line +
                                                       " Column: " + currentSymbol.Column);

                        if (currentSymbol.Character.Equals('*'))
                        {
                            currentSymbol = inputString.GetNextSymbol();
                            if (currentSymbol.Character.Equals('/'))
                            {
                                currentSymbol = inputString.GetNextSymbol();
                                break;
                            }
                        }
                        currentSymbol = inputString.GetNextSymbol();
                    }
                }
            }

            while (currentSymbol.Character.IsWhiteSpace())
            {
                currentSymbol = inputString.GetNextSymbol();
            }
        }
    }
}
