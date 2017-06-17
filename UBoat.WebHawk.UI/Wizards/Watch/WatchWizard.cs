using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Scheduling;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Notification;

namespace UBoat.WebHawk.UI.Wizards.Watch
{
    public class WatchWizard : Wizard
    {
        public WatchWizard()
            : base(null) { }
        public WatchWizard(ScheduledTask task) 
            : base(task) { }

        protected override ScheduledTask SetupTask()
        {
            ScheduledTask task = new ScheduledTask();
            //task.TaskSequence = new Sequence();
            //task.TaskSequence.SequenceSteps.Add(new NavigateStep());
            //task.TaskSequence.SequenceSteps.Add(new GetValueStep());
            //task.TaskSequence.SequenceSteps.Add(new NotifyStep()
            //{
            //    Notifications = new List<Notification>()
            //});
            return task;
        }

        protected override List<WizardPage> GetWizardPages()
        {
            return new List<WizardPage>()
            {
                new WatchWizardName(),
                new WatchWizardDOMSelector(),
                new WatchWizardRules(),
                new WatchWizardNotification(),
            };
        }
    }
}
