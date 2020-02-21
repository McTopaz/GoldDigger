using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GoldDigger.Common
{
    public static class Debug
    {
        public static void ToFile(Exception e, bool append = false)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var name = "GoldDiggerDebug.txt";
            var filePath = Path.Combine(path, name);
            var file = new FileInfo(filePath);

            var writer = append ? File.AppendText(file.FullName) : new StreamWriter(file.FullName);
            using (writer)
            {
                writer.WriteLine(e.Message);
                writer.WriteLine("");
                writer.WriteLine(e.StackTrace);
            }
        }
    }
}
