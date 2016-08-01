using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;
        
        //Consider a better name
        protected virtual void OnMailArrived(MailArrivedEventArgs mae)
        {
            //Nope. You missed the "elvis operator". it should be MailArrvied?.Invoke(this, mae). Notice the "?" before the dot.
            MailArrived.Invoke(this, mae);
        }

        public void SimulateMailArrived(Object o)
        {
            OnMailArrived((MailArrivedEventArgs)o);
            Console.WriteLine($"the time now is: { DateTime.Now.ToString("h:mm:ss.fff")}");
        }
    }


    public class MailArrivedEventArgs
    {
        public string Title { get; }
        public string Body { get;  }

        //Consider better names
        public MailArrivedEventArgs(string t, string b)
        {
            Title = t;
            Body = b; 
        }
        
    }
}
