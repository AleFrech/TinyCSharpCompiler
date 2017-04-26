using System.IO;

namespace ProjectCompi1
{
    public class FileManager
    {

        public string GetSourceCode(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
