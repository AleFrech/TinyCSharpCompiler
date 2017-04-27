using System.IO;

namespace Compiler
{
    public class FileManager
    {

        public string GetSourceCode(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
