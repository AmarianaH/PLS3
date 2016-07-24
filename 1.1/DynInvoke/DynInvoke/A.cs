using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    public class A
    {
        public string Hello(string s)
        {
            s = "Hello " + s;
            Console.WriteLine(s);
            return s;
        }
    }
}
