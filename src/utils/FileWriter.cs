using System.IO;

namespace windows_app.utils
{
    public static class FileWriter
    {
        public static void WriteToFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}