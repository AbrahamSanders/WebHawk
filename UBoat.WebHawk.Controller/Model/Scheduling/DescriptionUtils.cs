using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.Utils.Controls;

namespace UBoat.WebHawk.Controller.Model.Scheduling
{
    internal static class DescriptionUtils
    {
        public static string GetIntervalDescription(TimeSpan interval)
        {
            IntervalValue intervalValue = IntervalValue.FromTimeSpan(interval);
            switch (intervalValue.Unit)
            {
                case IntervalUnit.Milliseconds:
                    return String.Format("every {0}", intervalValue.Value.TotalMilliseconds == 1 ? "millisecond" : String.Format("{0} milliseconds", intervalValue.Value.TotalMilliseconds));
                case IntervalUnit.Seconds:
                    return String.Format("every {0}", intervalValue.Value.TotalSeconds == 1 ? "second" : String.Format("{0} seconds", intervalValue.Value.TotalSeconds));
                case IntervalUnit.Minutes:
                    return String.Format("every {0}", intervalValue.Value.TotalMinutes == 1 ? "minute" : String.Format("{0} minutes", intervalValue.Value.TotalMinutes));
                case IntervalUnit.Hours:
                    return String.Format("every {0}", intervalValue.Value.TotalHours == 1 ? "hour" : String.Format("{0} hours", intervalValue.Value.TotalHours));
                default:
                    throw new NotSupportedException();
            }
        }

        public static string BuildDescriptiveList<T>(IList<T> list, bool includeSpaceBetweenItems = true, bool useAndForLastItemSeparator = true, Func<T, string> formatListItem = null)
        {
            StringBuilder sb = new StringBuilder();
            BuildDescriptiveList<T>(list, sb, includeSpaceBetweenItems, useAndForLastItemSeparator, formatListItem);
            return sb.ToString();
        }

        public static void BuildDescriptiveList<T>(IList<T> list, StringBuilder sb, bool includeSpaceBetweenItems = true, bool useAndForLastItemSeparator = true, Func<T, string> formatListItem = null)
        {
            for (int x = 0; x < list.Count; x++)
            {
                if (x > 0)
                {
                    sb.Append(!useAndForLastItemSeparator || x < list.Count - 1 ? "," : " and");
                    if (includeSpaceBetweenItems)
                    {
                        sb.Append(" ");
                    }
                }
                if (formatListItem != null)
                {
                    sb.Append(formatListItem(list[x]));
                }
                else
                {
                    sb.Append(list[x]);
                }
            }
        }
    }
}
