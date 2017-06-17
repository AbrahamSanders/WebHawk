using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using UBoat.Utils;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Data
{
    public class DataContext
    {
        public Dictionary<string, IStateVariable> StateVariables { get; private set; }

        public DataContext()
        {
            this.StateVariables = new Dictionary<string, IStateVariable>();
        }

        public Dictionary<string, IStateVariable> GetPersistedVariables()
        {
            return this.StateVariables
                .Where(kvp => kvp.Value.PersistenceMode == PersistenceMode.Persisted)
                .ToDictionary(k => k.Key, v => v.Value.Copy(true));
        }

        public void LoadPersistedVariables(Dictionary<string, IStateVariable> persistedStateVariables)
        {
            this.StateVariables = persistedStateVariables
                .ToDictionary(k => k.Key, v => v.Value.Copy());
        }

        public string ToXml()
        {
            using (TextWriter writer = new UTF8StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Encoding = Encoding.UTF8,
                    Indent = true
                };
                using (XmlWriter xWriter = XmlWriter.Create(writer, settings))
                {
                    xWriter.WriteStartDocument();
                    xWriter.WriteStartElement(DataScope.RootScopeName);
                    foreach (IStateVariable stateVariable in this.StateVariables.Values)
                    {
                        zToXmlRecursive(stateVariable, xWriter, false);
                    }
                    xWriter.WriteEndElement();
                    xWriter.WriteEndDocument();
                }
                return writer.ToString();
            }
        }

        public void Clear()
        {
            //Perform a deep clear so that GC can collect nested lists and objects sooner.
            zRecursiveClearStateVariableCollection(this.StateVariables.Values);
            this.StateVariables.Clear();
        }

        private void zToXmlRecursive(IStateVariable stateVariable, XmlWriter xWriter, bool isList)
        {
            if (stateVariable.XMLFieldOutputMode != XMLFieldOutputMode.None)
            {
                string nodeName = isList && stateVariable is ObjectStateVariable
                    ? ((ObjectStateVariable)stateVariable).ObjectClassName
                    : stateVariable.Name;
                if (stateVariable.XMLFieldOutputMode == XMLFieldOutputMode.Element)
                {
                    xWriter.WriteStartElement(nodeName);
                }
                else
                {
                    xWriter.WriteStartAttribute(nodeName);
                }
                if (stateVariable is ListStateVariable)
                {
                    foreach (IStateVariable childVariable in ((ListStateVariable)stateVariable).Value)
                    {
                        zToXmlRecursive(childVariable, xWriter, true);
                    }
                }
                else if (stateVariable is ObjectStateVariable)
                {
                    foreach (IStateVariable memberVariable in ((ObjectStateVariable)stateVariable).Value.Values)
                    {
                        zToXmlRecursive(memberVariable, xWriter, false);
                    }
                }
                else
                {
                    xWriter.WriteString(stateVariable.ValueAsString());
                }
                if (stateVariable.XMLFieldOutputMode == XMLFieldOutputMode.Element)
                {
                    xWriter.WriteEndElement();
                }
                else
                {
                    xWriter.WriteEndAttribute();
                }
            }
        }

        private void zRecursiveClearStateVariableCollection(IEnumerable<IStateVariable> stateVariableCollection)
        {
            foreach (IStateVariable stateVariable in stateVariableCollection)
            {
                zRecursiveClearVariable(stateVariable);
            }
        }

        private void zRecursiveClearVariable(IStateVariable stateVariable)
        {
            if (stateVariable is ObjectStateVariable)
            {
                ObjectStateVariable objectStateVariable = (ObjectStateVariable)stateVariable;
                zRecursiveClearStateVariableCollection(objectStateVariable.Value.Values);
                objectStateVariable.Value.Clear();
            }
            if (stateVariable is ListStateVariable)
            {
                ListStateVariable listStateVariable = (ListStateVariable)stateVariable;
                zRecursiveClearStateVariableCollection(listStateVariable.Value);
                listStateVariable.Value.Clear();
            }
        }
    }
}
