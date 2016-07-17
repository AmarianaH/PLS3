using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = args[0];
            var sec = args[1];
            try
            {
                var files = Func(first, sec);
            
                Console.WriteLine($"all the files that contains the word {sec} ");
                foreach (string file in files)
                    Console.WriteLine($"the file name is : {file}");
            }
            catch (Exception e) {
                Console.WriteLine($"The process failed: {e.ToString()}");
            }
        }

        public static IEnumerable<string> Func(string first, string second)
        {
            StreamReader sr;
            var dirs = Directory.GetFiles(first);
            List<string> files = new List<string>();
            Console.WriteLine($"The number of all the files in this direction is : {dirs.Length}");
            foreach (string dir in dirs)
            {
                sr = new StreamReader(dir);
                var rte = sr.ReadToEnd();
                if (rte.Contains(second))
                {
                    files.Add(dir);
                    Console.WriteLine($"length of the file {dir} is {rte.Length} ");
                }
            }
            return files;
        }
    }
}
