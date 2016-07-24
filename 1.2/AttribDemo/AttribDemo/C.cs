using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace AttribDemo
{
    class C
    {
        [CodeReviewAttribute("Camil", "01/05/2001", true)]
        public void Hello()
        {
            MethodInfo methC = typeof(C).GetMethods()[0];
            foreach (object attribute in methC.GetCustomAttributes(typeof(CodeReviewAttribute)))
            {
                CodeReviewAttribute a = (CodeReviewAttribute)attribute;
                Console.WriteLine($"{methC.DeclaringType.Name} : \napproved : {a.CodeApproved} \nName : {a.ReviewName}  \nDate : {a.ReviewDate}");
                Console.WriteLine();
            }
        }

    }
}
