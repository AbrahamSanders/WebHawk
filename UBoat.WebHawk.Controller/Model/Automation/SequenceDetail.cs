using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.Controller.Model.Automation
{
    public class SequenceDetail
    {
        public Sequence Sequence { get; set; }
        public List<Step> SequenceSteps { get; set; }

        public SequenceDetail() 
            : this(null)
        {
        }
        public SequenceDetail(Sequence sequence)
            : this(sequence, new List<Step>())
        {
        }
        public SequenceDetail(Sequence sequence, List<Step> sequenceSteps)
        {
            this.Sequence = sequence;
            this.SequenceSteps = sequenceSteps;
        }

        public int CalculateStepCount()
        {
            return AutomationUtils.RecursiveStepCount(this.SequenceSteps);
        }
    }
}
