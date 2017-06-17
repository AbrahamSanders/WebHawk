using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;
using UBoat.Utils;

namespace UBoat.WebHawk.Controller.Notification
{
    internal class SMSNotify : INotify
    {
        public void Notify(Control UIContext, string address, string message)
        {
            message = String.Format("WebHawk Notification: {0}", message);

            WebRequest request = WebRequest.Create("http://textbelt.com/text");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            
            using (Stream requestStream = request.GetRequestStream())
            {
                string content = String.Format("number={0}&message={1}", HttpUtility.UrlEncode(address), HttpUtility.UrlEncode(message));
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
