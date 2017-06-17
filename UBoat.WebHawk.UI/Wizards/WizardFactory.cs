using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Scheduling;

namespace UBoat.WebHawk.UI.Wizards
{
    public static class WizardFactory
    {
        public static Wizard CreateWizard(SequenceType sequenceType)
        {
            return zCreateWizard(sequenceType, null);
        }

        public static Wizard CreateWizard(ScheduledTask task)
        {
            return zCreateWizard(task.TaskSequence.SequenceType, task);
        }

        private static Wizard zCreateWizard(SequenceType sequenceType, ScheduledTask task)
        {
            switch (sequenceType)
            {
                case SequenceType.Watch:
                    return new Watch.WatchWizard(task);
                case SequenceType.Scrape:
                    return new Scrape.ScrapeWizard(task);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
