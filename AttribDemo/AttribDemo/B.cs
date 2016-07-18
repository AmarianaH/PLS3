using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class B
    {
        [CodeReviewAttribute("Basil", "03/04/2015", false)]
        public void Hello()
        {
            MethodInfo methB = typeof(B).GetMethods()[0];
            foreach (object attribute in methB.GetCustomAttributes(typeof(CodeReviewAttribute)))
            {
                CodeReviewAttribute a = (CodeReviewAttribute)attribute;
                Console.WriteLine($"{methB.DeclaringType.Name} : \napproved : {a.CodeApproved} \nName : {a.ReviewName}  \nDate : {a.ReviewDate}");
                Console.WriteLine();
            }
        }
    }
}
