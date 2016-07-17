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
        
        protected virtual void OnMailArrived(MailArrivedEventArgs mae)
        {
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
        public MailArrivedEventArgs(string t, string b)
        {
            Title = t;
            Body = b; 
        }
        
    }
}
