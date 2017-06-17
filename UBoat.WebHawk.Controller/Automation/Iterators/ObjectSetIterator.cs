using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.WebHawk.Controller.Data;

namespace UBoat.WebHawk.Controller.Automation.Iterators
{
    internal abstract class ObjectSetIterator<T> : Iterator<T>, IObjectSetIterator where T : ObjectSetIteration
    {
        protected ObjectStateVariable m_CurrentObjectStateVariable;

        public Data.ObjectStateVariable CurrentObjectStateVariable
        {
            get 
            {
                return m_CurrentObjectStateVariable;
            }
        }

        public ObjectSetIteration ObjectSetIteration
        {
            get
            {
                return this.Iteration;
            }
        }

        protected ObjectSetIterator(T iteration) : base(iteration) { }
    }
}
