using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Automation.Steps
{
    [Serializable]
    public class WaitStep : Step
    {
        public TimeSpan Duration { get; set; }

        public WaitStep()
        {
            this.Duration = TimeSpan.FromSeconds(5);
        }

        protected override string get_DisplayNameImpl()
        {
            return "Wait";
        }
    }
}
