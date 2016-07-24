using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AttribDemo
{
    class A
    {
        [CodeReviewAttribute("Assaf","02/03/1992", true)]
        
        public void Hello()
        {
            MethodInfo methA = typeof(A).GetMethods()[0];
            foreach (object attribute in methA.GetCustomAttributes(typeof(CodeReviewAttribute)))
            {
                CodeReviewAttribute a = (CodeReviewAttribute)attribute;
                Console.WriteLine( $"{methA.DeclaringType.Name} : \napproved : {a.CodeApproved} \nName : {a.ReviewName}  \nDate : {a.ReviewDate}");
                Console.WriteLine();
            }
        }

        [CodeReview("ss","04/09/2011",true)]
        public void func2()
        {
            Console.WriteLine("hayyyy");
        }
    }
}
