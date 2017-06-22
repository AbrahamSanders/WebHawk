using System;
using System.Net;
using System.Net.Mail;
using UBoat.WebHawk.Controller.Model.Notification;

namespace UBoat.WebHawk.Controller.Notification
{
    internal class EmailNotify : Notify<EmailNotification>
    {
        public EmailNotify(EmailNotification notification) 
            : base(notification)
        {
        }

        public override void Send(string subject, string message)
        {
            using (SmtpClient smtp = new SmtpClient(Notification.SmtpHost))
            {
                smtp.Port = Notification.SmtpPort;
                smtp.Credentials = new NetworkCredential(Notification.SmtpUsername, Notification.SmtpPassword);
                smtp.EnableSsl = Notification.UseSSL;

                using (MailMessage email = new MailMessage())
                {
                    email.From = new MailAddress(Notification.FromAddress, Notification.FromAddressDisplayName);
                    foreach (string toAddress in Notification.ToAddresses)
                    {
                        email.To.Add(toAddress);
                    }
                    email.Subject = subject;
                    email.Body = message;
                    smtp.Send(email);
                }
            }
        }
    }
}
