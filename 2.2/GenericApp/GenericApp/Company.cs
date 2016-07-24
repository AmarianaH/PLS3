using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    [Key]
    public struct Company
    {
        public string Name;
        public string address;
        public string phoneNumber;

        public Company(string Name = "a", string address = "b", string phoneNumber= "c")
        {
            this.Name = Name;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"\nName = {Name} \t Address = {address} \tphoneNumber = {phoneNumber}";
        }
    }
}
