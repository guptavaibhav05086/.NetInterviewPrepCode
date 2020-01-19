using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepCode
{
    class DependencyInjection
    {
        
    }

    public interface INotificationSender
    {
        void SendMessage(string message);
    }
    public class Email : INotificationSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Email Sent Successfully");
        }
    }

    public class SMS : INotificationSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("SMS Sent Successfully");
        }
    }
    public class SendNotification
    {
        public readonly INotificationSender _NotificaionHandler;

        //In this code we are Injecting the Dependency using constructor Injection. 
        //Now this interface can handle any class that implemets it.So code is flexible now to add any new notification .which make our design extendable
        //Here also the calling method will decide which notifcation to send  
        public SendNotification(INotificationSender _NotificaionHandler)
        {
            this._NotificaionHandler = _NotificaionHandler;
        }

        public void Notification(string message)
        {
            //This code is tightly coupled.and can only be used for sending the Email and other type of Notification we need to chnage the code here
            //Email email = new Email();
            //email.SendMessage(message);
            _NotificaionHandler.SendMessage(message); 
        }
    }

   
}
