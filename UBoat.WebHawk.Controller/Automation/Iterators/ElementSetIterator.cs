using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;

namespace UBoat.WebHawk.Controller.Automation.Iterators
{
    internal class ElementSetIterator : ObjectSetIterator<ElementSetIteration>
    {
        private List<HtmlElement> m_Elements;
        private ListStateVariable m_ListStateVariable;

        public HtmlElement CurrentItem
        {
            get
            {
                int index = m_IterationCount - 1;
                if (m_Elements != null && index < m_Elements.Count)
                {
                    return m_Elements[index];
                }
                return null;
            }
        }

        public ListStateVariable ListStateVariable
        {
            get
            {
                return m_ListStateVariable;
            }
        }

        public ElementSetIterator(ElementSetIteration iteration, ListStateVariable listStateVariable) : base(iteration)
        {
            m_Elements = new List<HtmlElement>();
            m_ListStateVariable = listStateVariable;
        }

        public void SetElements(List<HtmlElement> elements)
        {
            m_Elements.Clear();
            m_Elements.AddRange(elements);
            m_CurrentObjectStateVariable = null;

            if (m_ListStateVariable != null)
            {
                if (m_Elements.Count > 0)
                {
                    zAddListItem();
                }
            }
        }

        public override void Iterate()
        {
            base.Iterate();

            if (m_ListStateVariable != null)
            {
                zAddListItem();
            }
        }

        public void RemoveCurrentObjectStateVariable()
        {
            if (m_CurrentObjectStateVariable != null)
            {
                m_ListStateVariable.Value.Remove(m_CurrentObjectStateVariable);
                m_CurrentObjectStateVariable = m_ListStateVariable.Value.LastOrDefault() as ObjectStateVariable;
            }
        }

        private void zAddListItem()
        {
            string listItemName = String.Format("{0}{1}", m_Iteration.ObjectSetClassName, m_IterationCount);
            m_CurrentObjectStateVariable = new ObjectStateVariable(listItemName, m_Iteration.ObjectSetClassName, m_Iteration.PersistenceMode, new Dictionary<string, IStateVariable>());
            m_ListStateVariable.Value.Add(m_CurrentObjectStateVariable);
        }

        protected override bool zCanIterate()
        {
            return m_IterationCount < m_Elements.Count;
        }
    }
}
