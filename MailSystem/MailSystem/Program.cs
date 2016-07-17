using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MailSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            MailManager mm = new MailManager();
            mm.MailArrived += MailArrivedEvent;
            mm.SimulateMailArrived(new MailArrivedEventArgs("cc","dd"));
            
            //Console.WriteLine($"the time now is: { DateTime.Now.ToString("h:mm:ss.fff")}");
            
            TimerCallback myTime = new TimerCallback(mm.SimulateMailArrived);

            Timer t = new Timer(myTime, new MailArrivedEventArgs("cc", "dd"), 2000, 1000);

            Console.ReadLine();
        }

        private static void MailArrivedEvent(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine("the Mail event args are:  ");
            Console.WriteLine(e.Body);
            Console.WriteLine(e.Title);
            
        }
    }
}
