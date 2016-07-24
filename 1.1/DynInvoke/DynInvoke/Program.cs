using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();

            string[] s1 = { "All" };
            string[] s2 = { "Mariana" };
            string[] s3 = { "Babyz" };

            InvokeHello(a, s1);
            Console.WriteLine();
            InvokeHello(b, s2);
            Console.WriteLine();
            InvokeHello(c, s3);
        }


        public static void InvokeHello(object obje , string[] str)
        {
            var methods = AppDomain.CurrentDomain.GetAssemblies()
                 .Select(x => x.GetTypes())
                 .SelectMany(x => x)
                 .Where(x => x.Namespace == "DynInvoke")
                 .Where(c => c.GetMethod("Hello") != null)
                 .Select(c => c.GetMethod("Hello"));
            object[] st = str;
            foreach (MethodInfo mi in methods)
            {
                //if (mi.IsStatic)
                //{
                //    mi.Invoke(obje,st);
                //}
                if (mi.DeclaringType.IsPublic)
                {
                    var obj = Activator.CreateInstance(mi.DeclaringType);
                    mi.Invoke(obj, st); 
                }
            }
        }
    }
}
