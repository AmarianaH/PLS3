using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var names = ReadFromFile("C:\\Users\\Mariana\\Source\\Repos\\PL3\\Names.txt");
                foreach(string name in names)
                {
                    Console.WriteLine(name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


        }


        public static IEnumerable<String> ReadFromFile(string FileName)
        {
            using (StreamReader sr = new StreamReader(FileName))
            {
                yield return sr.ReadToEnd();
            }
        }
    }
}