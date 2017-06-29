using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Automation.Iterators;

namespace UBoat.WebHawk.Controller.Automation
{
    internal class ExecutionBranch : IDisposable
    {
        internal struct MoveInfo
        {
            public MoveInfo(bool success, bool causedIteration)
            {
                this.Success = success;
                this.CausedIteration = causedIteration;
            }
            public bool Success;
            public bool CausedIteration;
        }

        private int m_CurrentPosition;
        private IIterator m_IterationContext;
        public List<Step> Steps { get; set; }

        public ExecutionBranch(List<Step> steps)
        {
            this.Steps = steps;
        }

        public int CurrentPosition
        {
            get
            {
                return m_CurrentPosition;
            }
        }

        public Step CurrentStep
        {
            get
            {
                return Steps[m_CurrentPosition];
            }
        }

        public IIterator IterationContext
        {
            get
            {
                return m_IterationContext;
            }
        }

        public MoveInfo MoveNext()
        {
            if (m_CurrentPosition < Steps.Count - 1)
            {
                m_CurrentPosition++;
                return new MoveInfo(true, false);
            }
            else if (m_IterationContext != null && m_IterationContext.CanIterate)
            {
                m_IterationContext.Iterate();
                Reset();
                return new MoveInfo(true, true);
            }
            return new MoveInfo(false, false);
        }

        public bool PeekNext()
        {
            bool canMoveNext = m_CurrentPosition < Steps.Count - 1;
            if (!canMoveNext && m_IterationContext != null && m_IterationContext.CanIterate)
            {
                canMoveNext = true;
            }
            return canMoveNext;
        }

        public void Reset()
        {
            m_CurrentPosition = 0;
        }

        public void EndBranch()
        {
            m_CurrentPosition = Steps.Count - 1;
        }

        public void SetIterator(IIterator iterator)
        {
            m_IterationContext = iterator;
        }

        public void RemoveIterator()
        {
            if (m_IterationContext != null)
            {
                m_IterationContext.Dispose();
                m_IterationContext = null;
            }
        }

        public int RecursiveStepCount()
        {
            return AutomationUtils.RecursiveStepCount(this.Steps);
        }

        public void Dispose()
        {
            RemoveIterator();
        }
    }
}
