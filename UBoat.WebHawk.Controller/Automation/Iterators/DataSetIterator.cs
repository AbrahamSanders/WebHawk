using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;

namespace UBoat.WebHawk.Controller.Automation.Iterators
{
    internal class DataSetIterator : ObjectSetIterator<DataSetIteration>
    {
        private List<ObjectStateVariable> m_DataSet;

        public DataSetIterator(DataSetIteration iteration)
            : base(iteration)
        {
            m_DataSet = new List<ObjectStateVariable>();
        }

        public void SetDataSet(IEnumerable<ObjectStateVariable> dataSet)
        {
            m_DataSet.Clear();
            if (m_Iteration.ObjectSetClassName != null)
            {
                m_DataSet.AddRange(dataSet.Where(osv => osv.ObjectClassName == m_Iteration.ObjectSetClassName));
            }
            else
            {
                m_DataSet.AddRange(dataSet);
            }

            zUpdateCurrentItem();
        }

        public override void Iterate()
        {
            base.Iterate();

            zUpdateCurrentItem();
        }

        private void zUpdateCurrentItem()
        {
            if (m_IterationCount <= m_DataSet.Count)
            {
                m_CurrentObjectStateVariable = m_DataSet[m_IterationCount - 1];
            }
            else
            {
                m_CurrentObjectStateVariable = null;
            }
        }

        protected override bool zCanIterate()
        {
            return m_IterationCount < m_DataSet.Count;
        }
    }
}
