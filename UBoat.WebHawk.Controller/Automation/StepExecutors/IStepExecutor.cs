using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal interface IStepExecutor
    {
        void LoadScope(Step step, ExecutionContext context);
        StepResult ExecuteStep();
    }
}
