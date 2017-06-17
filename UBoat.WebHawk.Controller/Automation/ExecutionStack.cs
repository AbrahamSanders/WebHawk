using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Automation.Iterators;

namespace UBoat.WebHawk.Controller.Automation
{
    internal class ExecutionStack
    {
        private List<ExecutionBranch> m_Branches;
        private int m_CurrentPosition;
        private ExecutionBranch m_CurrentBranch;
        private ExecutionBranch m_PendingBranch;
        private bool m_BreakBranch;
        private bool m_SkipIteration;

        public ExecutionBranch CurrentBranch
        {
            get
            {
                return m_CurrentBranch;
            }
        }

        public ExecutionBranch PendingBranch
        {
            get
            {
                return m_PendingBranch;
            }
        }

        public Step CurrentStep
        {
            get
            {
                return m_CurrentBranch.CurrentStep;
            }
        }

        public int CurrentPosition
        {
            get
            {
                return m_CurrentPosition;
            }
        }

        public ExecutionStack()
        {
            m_Branches = new List<ExecutionBranch>();
        }

        public void SetSequence(List<Step> sequence)
        {
            if (sequence.Count == 0)
            {
                throw new InvalidOperationException("Cannot set sequence without any steps.");
            }

            m_Branches.Clear();
            m_Branches.Add(new ExecutionBranch(sequence));
            this.Reset();
        }

        public void SetNewBranch(List<Step> branch)
        {
            SetNewBranch(branch, null);
        }
        public void SetNewBranch(List<Step> branch, IIterator iterator)
        {
            if (m_PendingBranch != null)
            {
                throw new InvalidOperationException("Cannot set new branch because there is already a branch pending. Call MoveNext first.");
            }
            if (branch.Count == 0)
            {
                throw new InvalidOperationException("Cannot set new branch without any steps.");
            }
            m_PendingBranch = new ExecutionBranch(branch);
            if (iterator != null)
            {
                m_PendingBranch.SetIterator(iterator);
            }
        }

        public void BreakBranch()
        {
            m_BreakBranch = true;
        }

        public void SkipIteration()
        {
            m_SkipIteration = true;
        }

        public void Reset()
        {
            m_BreakBranch = false;
            m_SkipIteration = false;
            while (m_Branches.Count > 1)
            {
                m_Branches.RemoveAt(m_Branches.Count - 1);
            }
            m_CurrentBranch = m_Branches[0];
            m_CurrentBranch.Reset();
            m_CurrentPosition = 0;
        }

        public bool MoveNext()
        {
            zCheckBreakOrSkip();

            if (m_PendingBranch != null)
            {
                m_Branches.Add(m_PendingBranch);
                m_CurrentBranch = m_PendingBranch;
                m_PendingBranch = null;
                m_CurrentPosition++;
                return true;
            }
            ExecutionBranch.MoveInfo moveInfo;
            while (!(moveInfo = m_CurrentBranch.MoveNext()).Success)
            {
                zOnBranchEnded(new BranchEndedEventArgs(m_CurrentBranch));
                if (m_Branches.Count == 1)
                {
                    return false;
                }
                m_CurrentBranch.Steps = null;
                m_Branches.RemoveAt(m_Branches.Count - 1);
                m_CurrentBranch = m_Branches[m_Branches.Count - 1];
            }
            m_CurrentPosition++;
            if (moveInfo.CausedIteration)
            {
                m_CurrentPosition -= m_CurrentBranch.RecursiveStepCount();
            }
            return true;
        }

        public bool PeekNext()
        {
            if (m_PendingBranch != null && !(m_BreakBranch || m_SkipIteration))
            {
                return true;
            }
            bool breakBranch = m_BreakBranch;
            bool skipIteration = m_SkipIteration;
            int branchIndex = m_Branches.Count - 1;
            while (breakBranch 
                || !m_Branches[branchIndex].PeekNext() 
                || (skipIteration && (m_Branches[branchIndex].IterationContext == null || !m_Branches[branchIndex].IterationContext.CanIterate)))
            {
                if (branchIndex == 0)
                {
                    return false;
                }
                breakBranch = false;
                skipIteration = false;
                branchIndex--;
            }
            return true;
        }

        public List<IIterator> GetActiveIterators()
        {
            List<IIterator> activeIterators = new List<IIterator>();
            foreach (ExecutionBranch branch in m_Branches)
            {
                if (branch.IterationContext != null)
                {
                    activeIterators.Add(branch.IterationContext);
                }
            }
            return activeIterators;
        }

        private void zCheckBreakOrSkip()
        {
            if (m_BreakBranch || m_SkipIteration)
            {
                m_PendingBranch = null;
                m_CurrentPosition = (m_CurrentPosition - (m_CurrentBranch.CurrentPosition + 1)) + m_CurrentBranch.RecursiveStepCount();
                m_CurrentBranch.EndBranch();
                if (m_BreakBranch)
                {
                    m_CurrentBranch.RemoveIterator();
                }
                m_BreakBranch = false;
                m_SkipIteration = false;
            }
        }

        public event EventHandler<BranchEndedEventArgs> BranchEnded;
        private void zOnBranchEnded(BranchEndedEventArgs e)
        {
            EventHandler<BranchEndedEventArgs> evnt = BranchEnded;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }
    }

    internal class BranchEndedEventArgs : EventArgs
    {
        public BranchEndedEventArgs(ExecutionBranch branch)
        {
            this.Branch = branch;
        }

        public ExecutionBranch Branch { get; set; }
    }
}
