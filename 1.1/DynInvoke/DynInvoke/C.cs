using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    public class C
    {
        public string Hello(string s)
        {
            s= "Nihau " + s;
            Console.WriteLine(s);
            return s;
        }

    }
}
