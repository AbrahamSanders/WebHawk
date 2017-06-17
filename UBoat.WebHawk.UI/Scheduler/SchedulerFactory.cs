using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Scheduling;

namespace UBoat.WebHawk.UI.Scheduler
{
    public static class SchedulerFactory
    {
        public static Scheduler GetScheduler(Schedule schedule)
        {
            if (schedule is HourlySchedule)
            {
                return new HourlyScheduler(schedule);
            }
            if (schedule is DailySchedule)
            {
                return new DailyScheduler(schedule);
            }
            if (schedule is WeeklySchedule)
            {
                return new WeeklyScheduler(schedule);
            }
            if (schedule is MonthlySchedule)
            {
                return new MonthlyScheduler(schedule);
            }

            throw new NotSupportedException();
        }
    }
}
