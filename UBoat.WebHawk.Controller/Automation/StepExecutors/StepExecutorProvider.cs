using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.Utils;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal class StepExecutorProvider : IDisposable
    {
        private Dictionary<Type, IStepExecutor> m_StepExecutorCache;

        public StepExecutorProvider()
        {
            m_StepExecutorCache = new Dictionary<Type, IStepExecutor>();
        }

        public IStepExecutor GetStepExecutor(Step step)
        {
            Type stepType = step.GetType();
            IStepExecutor stepExecutor;
            if (!m_StepExecutorCache.TryGetValue(stepType, out stepExecutor))
            {
                stepExecutor = zCreateStepExecutor(stepType);
                m_StepExecutorCache.Add(stepType, stepExecutor);
            }
            return stepExecutor;
        }

        private IStepExecutor zCreateStepExecutor(Type stepType)
        {
            if (stepType == typeof(NavigateStep))
            {
                return new NavigateStepExecutor();
            }
            if (stepType == typeof(ClickStep))
            {
                return new ClickStepExecutor();
            }
            if (stepType == typeof(GetValueStep))
            {
                return new GetValueStepExecutor();
            }
            if (stepType == typeof(SetValueStep))
            {
                return new SetValueStepExecutor();
            }
            if (stepType == typeof(NotifyStep))
            {
                return new NotifyStepExecutor();
            }
            if (stepType == typeof(DatabaseStep))
            {
                return new DatabaseStepExecutor();
            }
            if (stepType == typeof(GroupStep))
            {
                return new GroupStepExecutor();
            }

            throw new NotSupportedException();
        }

        public void Dispose()
        {
            if (m_StepExecutorCache != null)
            {
                m_StepExecutorCache.Clear();
                m_StepExecutorCache = null;
            }
        }
    }
}
