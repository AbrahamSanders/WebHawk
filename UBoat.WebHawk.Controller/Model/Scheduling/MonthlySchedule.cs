using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Scheduling
{
    [Serializable]
    public class MonthlySchedule : DailyRepeatableSchedule
    {
        public List<Month> MonthlyRecurrence { get; set; }
        public MonthlyRecurrenceType MonthlyRecurrenceType { get; set; }
        public List<int> OrdinalDays { get; set; }
        public List<WeekdayPosition> WeekdayPositions { get; set; }
        public List<DayOfWeek> Weekdays { get; set; }

        public MonthlySchedule()
        {
            this.MonthlyRecurrence = new List<Month>();
            this.OrdinalDays = new List<int>();
            this.WeekdayPositions = new List<WeekdayPosition>();
            this.Weekdays = new List<DayOfWeek>();
        }

        protected override void zBuildDescription(StringBuilder sb)
        {
            sb.Append("every ");
            if (MonthlyRecurrence.Count == 12)
            {
                sb.Append("month");
            }
            else
            {
                DescriptionUtils.BuildDescriptiveList(MonthlyRecurrence, sb);
            }

            sb.Append(" on ");
            if (MonthlyRecurrenceType == MonthlyRecurrenceType.OrdinalDays)
            {
                if ((OrdinalDays.Count == 31 && !OrdinalDays.Contains(-1)) || OrdinalDays.Count == 32)
                {
                    sb.Append("every day");
                }
                else
                {
                    sb.Append("the ");
                    DescriptionUtils.BuildDescriptiveList(OrdinalDays, sb, formatListItem: od =>
                    {
                        if (od == -1)
                        {
                            return "last day";
                        }
                        string dayStr = (od + 1).ToString();
                        return String.Format("{0}{1}", dayStr,
                            dayStr.EndsWith("1") && !dayStr.EndsWith("11") ? "st" :
                            dayStr.EndsWith("2") && !dayStr.EndsWith("12") ? "nd" :
                            dayStr.EndsWith("3") && !dayStr.EndsWith("13") ? "rd" : "th");
                    });
                }
            }
            else
            {
                sb.Append("the ");
                DescriptionUtils.BuildDescriptiveList(WeekdayPositions, sb);
                sb.Append(" ");
                DescriptionUtils.BuildDescriptiveList(Weekdays, sb);
            }
            sb.Append(" of the month ");
            base.zBuildDescription(sb);
        }
    }

    [Serializable]
    public enum Month
    {
        January = 0,
        February = 1,
        March = 2,
        April = 3,
        May = 4,
        June = 5,
        July = 6,
        August = 7,
        September = 8,
        October = 9,
        November = 10,
        December = 11
    }

    [Serializable]
    public enum MonthlyRecurrenceType
    {
        OrdinalDays,
        Weekdays
    }

    [Serializable]
    public enum WeekdayPosition
    {
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Last = -1
    }
}
