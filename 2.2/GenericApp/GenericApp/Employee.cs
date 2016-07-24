using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public class Employee
    {
        string Name;
        string SurName;
        int Age;
        int ID;

        public Employee()
        {
            Name = "defaultName";
            SurName = "defaultSurName";
            Age = 1;
            ID = 1;
        }


        public Employee(string Name, string SurName, int Age, int ID)
        {
            this.Name = Name;
            this.SurName = SurName;
            this.Age = Age;
            this.ID = ID;
        }

        public override String ToString()
        {
            return $"\nName = {Name} {SurName}";
        }

    }
}
