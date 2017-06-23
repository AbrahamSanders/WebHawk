using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal class WaitStepExecutor : StepExecutor<WaitStep>
    {
        protected override void zExecuteStep()
        {
            Timer timer = new Timer(m_Step.Duration.TotalMilliseconds);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (Timer timer = (Timer)sender)
            {
                timer.Elapsed -= timer_Elapsed;
                timer.Stop();
            }
            zCompleteStep(StepResult.Success);
        }
    }
}
