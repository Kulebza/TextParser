using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReader
{
    class FileWatcher
    {
        private static string resultFile = "result.txt";
        public static async void FileOnCreated(object sender, FileSystemEventArgs e)
        {
            if(e.Name != resultFile)
            await HandleFile(e.FullPath);
        }
        private static string GetParseResult(string fileEx, string text) => fileEx switch
        {
            ".txt" => TxtParser.Parse(text),
            ".css" => CssParser.Parse(text),
            ".html" => HtmlParser.Parse(text),
            _ => string.Empty,
        };

        private static async Task HandleFile(string path)
        {
            var text = File.ReadAllText(path);
            var res = GetParseResult(Path.GetExtension(path), text);

            if (!string.IsNullOrEmpty(res))
            {
                using (StreamWriter file = new StreamWriter(Path.Combine(Path.GetDirectoryName(path), resultFile), true))
                {
                    await file.WriteAsync($"{Path.GetFileName(path)}-{res}\n");
                }
            }
        }
    }
}
