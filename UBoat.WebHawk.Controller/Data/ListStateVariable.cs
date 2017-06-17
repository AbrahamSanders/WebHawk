using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Data
{
    [Serializable]
    public class ListStateVariable : StateVariable<List<IStateVariable>>
    {
        public ListStateVariable(string name, PersistenceMode persistenceMode, List<IStateVariable> value)
            : base(name, DataType.List, XMLFieldOutputMode.Element, persistenceMode, value)
        {
        }

        public bool IncludeInXML
        {
            get
            {
                return this.XMLFieldOutputMode == XMLFieldOutputMode.Element;
            }
            set
            {
                this.XMLFieldOutputMode = value 
                    ? XMLFieldOutputMode.Element 
                    : XMLFieldOutputMode.None;
            }
        }

        public override string ValueAsString()
        {
            return String.Empty;
        }

        public override IStateVariable Copy(bool persistedChildrenOnly = false)
        {
            return new ListStateVariable(
                this.Name,
                this.PersistenceMode,
                this.Value == null ? null : this.Value
                    .Where(sv => !persistedChildrenOnly || sv.PersistenceMode == PersistenceMode.Persisted)
                    .Select(sv => sv.Copy(persistedChildrenOnly))
                    .ToList());
        }
    }
}
