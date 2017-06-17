using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace UBoat.WebHawk.Controller.Notification
{
    internal class EmailNotify : INotify
    {
        public void Notify(Control UIContext, string address, string message)
        {
            
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("webhawknotify@gmail.com", "gT275t36O5V59w1");
                smtp.EnableSsl = true;

                using (MailMessage email = new MailMessage())
                {
                    email.From = new MailAddress("webhawknotify@gmail.com", "WebHawk Notification");
                    email.To.Add(address);
                    email.Subject = "WebHawk Notification!";
                    email.Body = message;
                    smtp.Send(email);
                }
            }
        }
    }
}
