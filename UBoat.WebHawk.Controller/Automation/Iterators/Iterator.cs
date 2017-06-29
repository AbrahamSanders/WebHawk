using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;

namespace UBoat.WebHawk.Controller.Automation.Iterators
{
    internal abstract class Iterator<T> : IIterator where T : Iteration
    {
        protected int m_IterationCount = 1;
        protected T m_Iteration;

        public T Iteration
        {
            get
            {
                return m_Iteration;
            }
        }

        protected Iterator(T iteration)
        {
            this.m_Iteration = iteration;
        }

        public virtual void Iterate()
        {
            m_IterationCount++;
        }

        public bool CanIterate
        {
            get 
            { 
                return zCanIterate(); 
            }
        }

        public virtual void Dispose()
        {
            //Override me if you have any disposable resources!
        }

        protected abstract bool zCanIterate();
    }
}
