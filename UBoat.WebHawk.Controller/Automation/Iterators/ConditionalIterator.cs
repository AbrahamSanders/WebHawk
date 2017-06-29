using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.WebHawk.Controller.Model.Conditional;

namespace UBoat.WebHawk.Controller.Automation.Iterators
{
    internal class ConditionalIterator : Iterator<ConditionalIteration>
    {
        private ExecutionContext m_Context;
        private DataScope m_DataScope;
        private ConditionNode m_Condition;

        public ConditionalIterator(ConditionalIteration iteration, ExecutionContext context, DataScope dataScope) : base(iteration)
        {
            m_Context = context;
            m_DataScope = dataScope;
        }

        public void SetCondition(ConditionNode condition)
        {
            m_Condition = condition;
        }

        protected override bool zCanIterate()
        {
            if (m_Condition == null)
            {
                return false;
            }
            return m_Context.ConditionalEngine.CheckCondition(m_Condition, m_DataScope);
        }

        public override void Dispose()
        {
            base.Dispose();

            m_Context = null;

            m_DataScope.Dispose();
            m_DataScope = null;
        }
    }
}
