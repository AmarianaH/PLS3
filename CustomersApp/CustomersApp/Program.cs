using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CustomersApp
{
    class Program
    {
        static IEnumerable<Customer> GetCustomer(IEnumerable<Customer> customers, CustomerFilter CustFilter)
        {
            var l = new List<Customer>();
            foreach(Customer customer in customers)
            {
                if( CustFilter(customer))
                {
                    l.Add(customer);
                }
            }
            return l;
        }

        static bool ifAtoK(Customer c)
        {
            return Regex.IsMatch(c.name, "^[A-K]");
        }
        
        static void printCollection(IEnumerable<Customer> coll)
        {
            foreach (Customer i in coll)
                Console.WriteLine($"{i.name,10}  {i.ID,10}");

        }

        static void Main(string[] args)
        {
            List<Customer> custs = new List<Customer>();
            
            custs.Add(new Customer("Mariana", 100, "aa"));
            custs.Add(new Customer("Kmaria", 101, "bb"));
            custs.Add(new Customer("Zmana", 99, "cc"));
            custs.Add(new Customer("Gana", 103, "dd"));
            custs.Add(new Customer("Ymana", 80, "ee"));
            custs.Add(new Customer("Bmariana", 100, "ff"));

            printCollection(custs);
                custs.Sort();

            Console.WriteLine();
            Console.WriteLine("Ther Customers list sorted by name only : ");
            printCollection(custs);

            //////------------------------------the first delegate :
            CustomerFilter cf = ifAtoK;
            IEnumerable<Customer> AtoK = new List<Customer>();


            AtoK = GetCustomer(custs, cf);
            
            if (AtoK != null)
            {
                Console.WriteLine();
                Console.WriteLine("all the names that starts with k and a are: ");
                printCollection(AtoK);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("there is no names that starts with k and a "); 
            }
            //////--------------------- Another delegate :

            var LtoZ = GetCustomer(custs, delegate (Customer c) {
                return Regex.IsMatch(c.name, "^[L-Z]");
            });

            Console.WriteLine();
            Console.WriteLine("all the names that starts with k and a are: ");
            printCollection(LtoZ);

            /////// --------------------- Delegate to the IDs : 

            var Ids = GetCustomer(custs, c => (c.ID < 100));
            Console.WriteLine();
            Console.WriteLine("All customers with ID less than 100");
            printCollection(Ids);
        }
        
    }
}
