using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils;
using UBoat.WebHawk.Controller.Common;
using UBoat.WebHawk.Controller.Persistence;

namespace UBoat.WebHawk.Controller.Settings
{
    public class SettingsController : ControllerBase
    {
        public SettingsController(string connectionString)
            : base(connectionString)
        {
        }

        public bool TryGetSettingValue<T>(WebHawkSettings setting, out T value)
        {
            value = default(T);
            try
            {
                string valueString = GetSettingValue(setting);
                if (valueString != null)
                {
                    value = (T)Convert.ChangeType(valueString, typeof(T));
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetSettingValue(WebHawkSettings setting)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                return data.GetSettingValue(setting.ToString());
            }
        }

        public void SetSettingValue(WebHawkSettings setting, string value)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                data.SetSettingValue(setting.ToString(), value);
            }
            if (setting == WebHawkSettings.StartWithWindows)
            {
                zSyncStartupItem();
            }
        }

        private bool zSyncStartupItem()
        {
            try
            {
                bool startWithWindows;
                if (this.TryGetSettingValue<bool>(WebHawkSettings.StartWithWindows, out startWithWindows))
                {
                    string startupItemName = "WebHawk";
                    string startupItem = RegistryUtils.GetWindowsStartupItem(startupItemName);
                    if (startWithWindows && startupItem == null)
                    {
                        RegistryUtils.AddWindowsStartupItem(startupItemName, String.Format("\"{0}\" {1}", Application.ExecutablePath, "/m"));
                    }
                    if (!startWithWindows && startupItem != null)
                    {
                        RegistryUtils.RemoveWindowsStartupItem(startupItemName);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
