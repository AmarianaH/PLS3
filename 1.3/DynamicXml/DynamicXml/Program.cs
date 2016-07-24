using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Dynamic;

namespace DynamicXml
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic planets = DynamicXElement.Create(XElement.Load(@"C:\Users\Mariana\Documents\Visual Studio 2015\Projects\DynamicXml\DynamicXml\planets.xml"));
            var mercury = planets.Planet;    
            Console.WriteLine(mercury);
            var venus = planets["Planet", 1]; 
            Console.WriteLine(venus);
            var ourMoon = planets["Planet", 2].Moons.Moon;
            Console.WriteLine(ourMoon);
            var marsMoon = planets["Planet", 3]["Moons", 0].Moon; // mars second moon
            Console.WriteLine(marsMoon);
            var moons = planets["Planet", 3]["Moons", 0];
            var moon1 = moons["Moon", 0];
            var moon2 = moons["Moon", 1];
            var moon3 = moons["Moon", 2];

            Console.WriteLine($"moons : {moons}");
            Console.WriteLine($"moon1 : {moon1}");
            Console.WriteLine($"moon2 : {moon2}");
            Console.WriteLine($"moon3 : {moon3}");

        }
    }
}
