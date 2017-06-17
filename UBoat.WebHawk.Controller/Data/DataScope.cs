using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Data
{
    public class DataScope : IDisposable
    {
        public const string RootScopeName = "Root";

        private Dictionary<string, Dictionary<string, IStateVariable>> m_StateVariables;
        private string m_CurrentScopeName;

        public DataScope()
        {
            m_StateVariables = new Dictionary<string, Dictionary<string, IStateVariable>>();
            m_CurrentScopeName = DataScope.RootScopeName;
        }

        public void Add(string scopeName, Dictionary<string, IStateVariable> stateVariables)
        {
            m_StateVariables.Add(scopeName, stateVariables);
            m_CurrentScopeName = scopeName;
        }

        public IStateVariable GetStateVariable(string stateVariableName)
        {
            if (String.IsNullOrEmpty(stateVariableName))
            {
                return null;
            }

            string scopeNamePart;
            string variableNamePart;
            DataUtils.ParseStateVariableName(m_CurrentScopeName, stateVariableName, out scopeNamePart, out variableNamePart);

            Dictionary<string, IStateVariable> scopedStateVariables;
            if (m_StateVariables.TryGetValue(scopeNamePart, out scopedStateVariables))
            {
                IStateVariable stateVariable;
                if (scopedStateVariables.TryGetValue(variableNamePart, out stateVariable))
                {
                    return stateVariable;
                }
            }
            return null;
        }

        public void SetStateVariable(string stateVariableName, IStateVariable stateVariable)
        {
            if (!String.IsNullOrEmpty(stateVariableName) && stateVariable != null)
            {
                if (m_StateVariables.Count == 0)
                {
                    this.Add(m_CurrentScopeName, new Dictionary<string, IStateVariable>());
                }

                string scopeNamePart;
                string variableNamePart;
                DataUtils.ParseStateVariableName(m_CurrentScopeName, stateVariableName, out scopeNamePart, out variableNamePart);

                Dictionary<string, IStateVariable> scopedStateVariables;
                if (!m_StateVariables.TryGetValue(scopeNamePart, out scopedStateVariables))
                {
                    throw new ArgumentException(String.Format("Data Scope \"{0}\" was not found.", scopeNamePart));
                }
                scopedStateVariables[variableNamePart] = stateVariable;
            }
        }

        public void Dispose()
        {
            //Clear state variable collection, otherwise GC will pick this object up when hell freezes over.
            if (m_StateVariables != null)
            {
                m_StateVariables.Clear();
                m_StateVariables = null;
            }
        }
    }
}
