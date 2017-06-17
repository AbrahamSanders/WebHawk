using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Scheduling;

namespace UBoat.WebHawk.Controller.Scheduling
{
    internal static class TriggerBuilderFactory
    {
        public static List<TriggerBuilder> CreateForSchedule(string triggerName, Schedule schedule)
        {
            List<TriggerBuilder> triggerBuilderList = new List<TriggerBuilder>();

            if (schedule is OneTimeSchedule)
            {
                zConfigureOneTimeSchedule(triggerBuilderList, (OneTimeSchedule)schedule);
            }
            if (schedule is HourlySchedule)
            {
                zConfigureHourlySchedule(triggerBuilderList, (HourlySchedule)schedule);
            }
            if (schedule is DailySchedule)
            {
                zConfigureDailySchedule(triggerBuilderList, (DailySchedule)schedule);
            }
            if (schedule is WeeklySchedule)
            {
                zConfigureWeeklySchedule(triggerBuilderList, (WeeklySchedule)schedule);
            }
            if (schedule is MonthlySchedule)
            {
                zConfigureMonthlySchedule(triggerBuilderList, (MonthlySchedule)schedule);
            }

            for (int x = 0; x < triggerBuilderList.Count; x++)
            {
                triggerBuilderList[0] = triggerBuilderList[0]
                    .WithIdentity(String.Format("{0}_{1}", triggerName, x), TriggerKey.DefaultGroup)
                    .StartAt(schedule.StartTimeUtc)
                    .EndAt(schedule.EndTimeUtc);
            }

            return triggerBuilderList;
        }

        private static void zConfigureOneTimeSchedule(List<TriggerBuilder> triggerBuilderList, OneTimeSchedule schedule)
        {
            SimpleScheduleBuilder sb = zCreateSimpleSchedule(schedule)
                .WithRepeatCount(0);

            triggerBuilderList.Add(TriggerBuilder.Create().WithSchedule(sb));
        }

        private static void zConfigureHourlySchedule(List<TriggerBuilder> triggerBuilderList, HourlySchedule schedule)
        {
            SimpleScheduleBuilder sb = zCreateSimpleSchedule(schedule)
                .WithInterval(schedule.HourlyRecurrence)
                .RepeatForever();

            triggerBuilderList.Add(TriggerBuilder.Create().WithSchedule(sb));
        }

        private static void zConfigureDailySchedule(List<TriggerBuilder> triggerBuilderList, DailySchedule schedule)
        {
            DailyTimeIntervalScheduleBuilder sb = zCreateDailyTimeIntervalSchedule(schedule)
                .OnEveryDay();

            triggerBuilderList.Add(TriggerBuilder.Create().WithSchedule(sb));
        }

        private static void zConfigureWeeklySchedule(List<TriggerBuilder> triggerBuilderList, WeeklySchedule schedule)
        {
            DailyTimeIntervalScheduleBuilder sb = zCreateDailyTimeIntervalSchedule(schedule)
                .OnDaysOfTheWeek(schedule.WeeklyRecurrence.ToArray());

            triggerBuilderList.Add(TriggerBuilder.Create().WithSchedule(sb));
        }

        private static void zConfigureMonthlySchedule(List<TriggerBuilder> triggerBuilderList, MonthlySchedule schedule)
        {
            if (schedule.MonthlyRecurrenceType == MonthlyRecurrenceType.OrdinalDays || schedule.WeekdayPositions.Count == 5)
            {
                triggerBuilderList.Add(zCreateMonthlyTriggerBuilder(schedule, null, null));
            }
            else
            {
                foreach (WeekdayPosition weekdayPosition in schedule.WeekdayPositions)
                {
                    foreach (DayOfWeek weekDay in schedule.Weekdays)
                    {
                        triggerBuilderList.Add(zCreateMonthlyTriggerBuilder(schedule, weekdayPosition, weekDay));
                    }
                }
            }
        }

        private static TriggerBuilder zCreateMonthlyTriggerBuilder(MonthlySchedule schedule, WeekdayPosition? weekdayPosition, DayOfWeek? weekDay)
        {
            string cronExpression = String.Format("{0} {1} {2} {3} {4} {5}",
                        zCronSecondValue(schedule),
                        zCronMinuteValue(schedule),
                        zCronHourValue(schedule),
                        zCronDayOfMonthValue(schedule),
                        zCronMonthValue(schedule),
                        zCronDayOfWeekValue(schedule, weekdayPosition, weekDay));

            return TriggerBuilder.Create()
                .WithCronSchedule(cronExpression, sb =>
                    sb.WithMisfireHandlingInstructionDoNothing());
        }

        private static string zCronSecondValue(MonthlySchedule schedule)
        {
            if (schedule.RepeatsDailyOnInterval)
            {
                if (schedule.DailyRepetitionInterval.Seconds != 0)
                {
                    return String.Format("0/{0}", schedule.DailyRepetitionInterval.Seconds);
                }
                else
                {
                    return schedule.DailyRepetitionStartTimeUtc
                        .ToLocalTime()
                        .Second
                        .ToString();
                }
            }
            else
            {
                return schedule.StartTimeUtc
                    .ToLocalTime()
                    .Second
                    .ToString();
            }
        }

        private static string zCronMinuteValue(MonthlySchedule schedule)
        {
            if (schedule.RepeatsDailyOnInterval)
            {
                if (schedule.DailyRepetitionInterval.Minutes != 0)
                {
                    return String.Format("0/{0}", schedule.DailyRepetitionInterval.Minutes);
                }
                else if (schedule.DailyRepetitionInterval.Seconds != 0)
                {
                    return "0/1";
                }
                else
                {
                    return schedule.DailyRepetitionStartTimeUtc
                        .ToLocalTime()
                        .Minute
                        .ToString();
                }
            }
            else
            {
                return schedule.StartTimeUtc
                    .ToLocalTime()
                    .Minute
                    .ToString();
            }
        }

        private static string zCronHourValue(MonthlySchedule schedule)
        {
            if (schedule.RepeatsDailyOnInterval)
            {
                if (schedule.DailyRepetitionInterval.Hours != 0)
                {
                    return String.Format("0/{0}", schedule.DailyRepetitionInterval.Hours);
                }
                else
                {
                    return "0/1";
                }
            }
            else
            {
                return schedule.StartTimeUtc
                    .ToLocalTime()
                    .Hour
                    .ToString();
            }
        }

        private static string zCronDayOfMonthValue(MonthlySchedule schedule)
        {
            if (schedule.MonthlyRecurrenceType == MonthlyRecurrenceType.OrdinalDays)
            {
                if ((schedule.OrdinalDays.Count == 31 && !schedule.OrdinalDays.Contains(-1)) || schedule.OrdinalDays.Count == 32)
                {
                    return "*";
                }
                else
                {
                    //The documentation says that using L with a list could cause unexpected results. If this doesn't work, find other way to do this.
                    return DescriptionUtils.BuildDescriptiveList(schedule.OrdinalDays, false, false, od => od > -1 ? ((int)od + 1).ToString() : "L");
                }
            }
            else
            {
                return "?";
            }
        }

        private static string zCronMonthValue(MonthlySchedule schedule)
        {
            if (schedule.MonthlyRecurrence.Count == 12)
            {
                return "*";
            }
            else
            {
                return DescriptionUtils.BuildDescriptiveList(schedule.MonthlyRecurrence, false, false, m => ((int)m + 1).ToString());
            }
        }

        private static string zCronDayOfWeekValue(MonthlySchedule schedule, WeekdayPosition? weekdayPosition, DayOfWeek? weekDay)
        {
            if (schedule.MonthlyRecurrenceType == MonthlyRecurrenceType.Weekdays)
            {
                if (weekdayPosition.HasValue && weekDay.HasValue)
                {
                    if (weekdayPosition.Value == WeekdayPosition.Last)
                    {
                        return String.Format("{0}L", (int)weekDay.Value + 1);
                    }
                    else
                    {
                        return String.Format("{0}#{1}", (int)weekDay.Value + 1, weekdayPosition.Value + 1);
                    }
                }
                else if (schedule.Weekdays.Count == 7)
                {
                    return "*";
                }
                else
                {
                    return DescriptionUtils.BuildDescriptiveList(schedule.Weekdays, false, false, wd => ((int)wd + 1).ToString());
                }
            }
            else
            {
                return "?";
            }
        }

        private static SimpleScheduleBuilder zCreateSimpleSchedule(Schedule schedule)
        {
            SimpleScheduleBuilder sb = SimpleScheduleBuilder.Create();
            switch (schedule.MissedScheduleMode)
            {
                case MissedScheduleMode.RunImmediately:
                    sb = sb.WithMisfireHandlingInstructionFireNow();
                    break;
                case MissedScheduleMode.RunAtNextScheduledTime:
                    sb = sb.WithMisfireHandlingInstructionNextWithRemainingCount();
                    break;
                default:
                    throw new NotSupportedException();
            }
            return sb;
        }

        private static DailyTimeIntervalScheduleBuilder zCreateDailyTimeIntervalSchedule(DailyRepeatableSchedule schedule)
        {
            DailyTimeIntervalScheduleBuilder sb = DailyTimeIntervalScheduleBuilder.Create();
            switch (schedule.MissedScheduleMode)
            {
                case MissedScheduleMode.RunImmediately:
                    sb = sb.WithMisfireHandlingInstructionFireAndProceed();
                    break;
                case MissedScheduleMode.RunAtNextScheduledTime:
                    sb = sb.WithMisfireHandlingInstructionDoNothing();
                    break;
                default:
                    throw new NotImplementedException();
            }
            if (schedule.RepeatsDailyOnInterval)
            {
                sb = sb.StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(
                        schedule.DailyRepetitionStartTimeUtc.Hour,
                        schedule.DailyRepetitionStartTimeUtc.Minute,
                        schedule.DailyRepetitionStartTimeUtc.Second))
                    .WithIntervalInSeconds((int)schedule.DailyRepetitionInterval.TotalSeconds)
                    .EndingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(
                        schedule.DailyRepetitionEndTimeUtc.Hour,
                        schedule.DailyRepetitionEndTimeUtc.Minute,
                        schedule.DailyRepetitionEndTimeUtc.Second));
            }
            else
            {
                sb = sb.StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(
                    schedule.StartTimeUtc.Hour,
                    schedule.StartTimeUtc.Minute,
                    schedule.StartTimeUtc.Second))
                    .WithIntervalInHours(24);
            }
            return sb;
        }
    }
}
