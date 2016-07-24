using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            A a = new A();
            B b = new B();
            C c = new C();
            Console.WriteLine("all the Hello functions attributes: ");
            a.Hello();
            b.Hello();
            c.Hello();
            Console.WriteLine();
            
            MethodInfo[] methods = new MethodInfo[3] { typeof(A).GetMethod("Hello"), typeof(B).GetMethod("Hello"), typeof(C).GetMethod("Hello") };

            Console.WriteLine("if the Code is approved: ");
            foreach (MethodInfo meth in methods)
            {
                if (AnalayzeAssembly(meth))
                {
                    Console.WriteLine($"the Code of the method {meth.Name} in class : {meth.DeclaringType.Name} -- is Approved ");
                }
                else Console.WriteLine($"the Code of the method {meth.Name} in class : {meth.DeclaringType.Name} -- is Not Approved");
            }


            Console.WriteLine();
            Console.WriteLine("Sending another assembly: ");
            MethodInfo m = typeof(A).GetMethod("func2");
            Console.WriteLine(AnalayzeAssembly(m));
        }

        private static bool AnalayzeAssembly(MethodInfo assem)
        {
            
            foreach (object attribute in assem.GetCustomAttributes(typeof(CodeReviewAttribute)))
            {
                if (attribute is CodeReviewAttribute )
                {
                    CodeReviewAttribute a = (CodeReviewAttribute)attribute;
                    if (a.CodeApproved == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
