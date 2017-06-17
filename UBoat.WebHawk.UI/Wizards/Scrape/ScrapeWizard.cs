using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Scheduling;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.UI.Wizards.Scrape
{
    public class ScrapeWizard : Wizard
    {
        public ScrapeWizard()
            : base(null) { }
        public ScrapeWizard(ScheduledTask task) 
            : base(task) { }

        protected override ScheduledTask SetupTask()
        {
            ScheduledTask task = new ScheduledTask();
            task.TaskSequence = new Sequence();
            return task;
        }

        protected override List<WizardPage> GetWizardPages()
        {
            return new List<WizardPage>()
            {
                new ScrapeWizardName()
                //new ScrapeWizardDOMSelector(),
                //new ScrapeWizardDataSource(),
                //new ScrapeWizardScheduling(),
            };
        }
    }
}
