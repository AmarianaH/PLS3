using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{

    class Program
    {
        static void Main(string[] args)
        {
            MultiDictionary<Company, Employee> emps = new MultiDictionary<Company, Employee>();
            Company c = new Company("CodeValue","Yokniam","04-6592637");
            Company c1 = new Company("GalilSoftware", "Nazareth", "04-6579626");
            Employee e = new Employee("Mariana", "abuhattoum", 24, 100);
            Employee e1 = new Employee("Moaiad", "Hathoot", 27, 101);

            emps.Add(c, e);
            emps.Add(c, e1);
            emps.Add(c1, new Employee("Khaldoon", "safadi", 24, 102));
            emps.Add(c1, e);
            emps.Add(c1, new Employee("Maroun", "Sassin", 26, 103));
            emps.Add(c1, new Employee("Nizar", "Haddad", 25, 104));
            Console.WriteLine("After Adding Companies and employees: ");
            print(emps);
            Console.WriteLine();
            Console.WriteLine($"contains Mariana in CodeValue? {emps.Contains(c,e)}");
            Console.WriteLine($"contains Moaiad in Galilsoftware? {emps.Contains(c1,e1)}");
            Console.WriteLine($"CodeValue is in the list? {emps.ContainsKey(c)}");
            Console.WriteLine($"the number of the Companies :  {emps.Keys.Count}");
            Console.WriteLine($"the number of all the employees is : {emps.Values.Count}");
            Console.WriteLine($"adding a default employee to GalilSoftware..");
            emps.CreateNewValue(c1); 
            Console.WriteLine("Now printing the new Dictionary: ");
            print(emps);
            Console.WriteLine("\n");
            Console.WriteLine($"removing Mariana From Galil.. {emps.Remove(c1,e)}");
            Console.WriteLine($"Removing CodeValue From the Dictionary.. {emps.Remove(c)} ");
            Console.WriteLine("Now printing the new Dictionary: ");
            print(emps);
           
        }
        
        public static void print(MultiDictionary<Company,Employee> dictionary )
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"\nkey : {item.Key.ToString()} \n\nValues:{item.Value.Select(i => i.ToString()).Aggregate((a,b) => $"{a},{b}")} ");
            }
        }
    }
}
