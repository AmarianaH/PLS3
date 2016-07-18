using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    public class CodeReviewAttribute : Attribute
    {
        public string ReviewName; 
        public DateTime ReviewDate; 
        public bool CodeApproved;
       // public Attribute AttributeUsage;

        //internal string func()
        //{
        //    return ($"{ReviewName} , {ReviewDate} , {CodeApproved} ");
        //}

        public CodeReviewAttribute(string Name, string Date, bool Approved)
        {
            ReviewName = Name;
            ReviewDate = DateTime.Parse(Date);
            CodeApproved = Approved;
        }





    }
}
