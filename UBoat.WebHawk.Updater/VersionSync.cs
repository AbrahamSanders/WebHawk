using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace UBoat.WebHawk.Updater
{
    public static class VersionSync
    {
        public static string GetLatestVersion()
        {
            WebRequest request = HttpWebRequest.Create("http://www.uboatsoft.com/WebHawk/LatestVersion.html");
            string responseString;
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    responseString = sr.ReadToEnd();
                }
            }
            return responseString;
        }

        public static string GetCurrentVersion()
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebHawk.exe");
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(exePath);
            return versionInfo.ToString();
        }
    }
}
