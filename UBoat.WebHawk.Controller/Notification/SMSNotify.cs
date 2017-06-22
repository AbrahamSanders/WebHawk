using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using UBoat.Utils;
using UBoat.WebHawk.Controller.Model.Notification;

namespace UBoat.WebHawk.Controller.Notification
{
    internal class SMSNotify : Notify<SMSNotification>
    {
        public SMSNotify(SMSNotification notification)
            : base(notification)
        {
        }

        public override void Send(string subject, string message)
        {
            string smsMessage = String.Format("{0}: {1}", subject, message);

            foreach (string number in Notification.Numbers)
            {
                WebRequest request = WebRequest.Create(Notification.TextbeltAPIURL);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
            
                using (Stream requestStream = request.GetRequestStream())
                {
                    string content = String.Format("number={0}&message={1}", HttpUtility.UrlEncode(number), HttpUtility.UrlEncode(smsMessage));
                    if (Notification.TextbeltAPIKey != null)
                    {
                        content = String.Format("{0}&key={1}", HttpUtility.UrlEncode(Notification.TextbeltAPIKey));
                    }
                    byte[] buffer = Encoding.UTF8.GetBytes(content);
                    requestStream.Write(buffer, 0, buffer.Length);
                }
                string responseContent;
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader responseStreamReader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = responseStreamReader.ReadToEnd();
                    }
                }
                SMSResult result = Converter.FromJSON<SMSResult>(responseContent);
            }
        }
    }
}
