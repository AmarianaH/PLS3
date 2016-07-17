using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    public class B
    {
        public string Hello(string s)
        {
            s = "Bonjour " + s;
            Console.WriteLine(s);
            return s;
        }
    }
}
