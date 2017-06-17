using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;

namespace UBoat.WebHawk.Controller.Automation.Iterators
{
    internal class FixedIterator : Iterator<FixedIteration>
    {
        public FixedIterator(FixedIteration iteration) : base(iteration)
        {
        }

        protected override bool zCanIterate()
        {
            return m_IterationCount < m_Iteration.Iterations;
        }
    }
}
