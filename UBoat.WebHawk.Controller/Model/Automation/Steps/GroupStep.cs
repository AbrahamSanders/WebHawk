using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;

namespace UBoat.WebHawk.Controller.Model.Automation.Steps
{
    [Serializable]
    public class GroupStep : Step
    {
        public List<Step> Steps { get; set; }
        public Iteration Iteration { get; set; }

        public GroupStep()
        {
            this.Steps = new List<Step>();
        }

        protected override string get_DisplayNameImpl()
        {
            return "Group"; 
        }
    }
}
