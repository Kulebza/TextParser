using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextReader
{
    class Program
    {                
        static int Main(string[] args)
        {
            var folder = args[0];
            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder))
            {
                Console.WriteLine("Wrong path");
                return 0;
            }

            using var watcher = new FileSystemWatcher(folder);

            watcher.NotifyFilter =  NotifyFilters.FileName;
            watcher.Created += FileWatcher.FileOnCreated;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Watcher is working");            
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
            return 0;
        }
    }
}
