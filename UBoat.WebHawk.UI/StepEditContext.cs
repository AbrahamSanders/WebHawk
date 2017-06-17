using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.UI
{
    public class StepEditContext
    {
        public Step Step { get; set; }
        public List<Step> Sequence { get; set; }
        public Dictionary<Step, int> StepIndex { get; set; }
        public List<StateVariableInfo> StateVariables { get; set; }

        public StepEditContext(Step step, List<Step> sequence, Dictionary<Step, int> stepIndex, List<StateVariableInfo> stateVariables)
        {
            this.Step = step;
            this.Sequence = sequence;
            this.StepIndex = stepIndex;
            this.StateVariables = stateVariables;
        }

        /// <summary>
        /// Returns the 1 based position of Step in Sequence. If Step does not exist in Sequence, returns -1.
        /// </summary>
        /// <returns></returns>
        public int GetEditStepPosition()
        {
            int editStepPosition;
            if (!this.StepIndex.TryGetValue(this.Step, out editStepPosition))
            {
                editStepPosition = -1;
            }
            return editStepPosition;
        }
    }
}
