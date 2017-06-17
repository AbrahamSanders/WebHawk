using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Data
{
    [Serializable]
    public class ObjectStateVariable : StateVariable<Dictionary<string, IStateVariable>>
    {
        public string ObjectClassName { get; set; }

        public ObjectStateVariable(string name, string objectClassName, PersistenceMode persistenceMode, Dictionary<string, IStateVariable> value) 
            : base(name, DataType.Object, XMLFieldOutputMode.Element, persistenceMode, value)
        {
            this.ObjectClassName = objectClassName;
        }

        public override string ValueAsString()
        {
            return String.Empty;
        }

        public override IStateVariable Copy(bool persistedChildrenOnly = false)
        {
            return new ObjectStateVariable(
                this.Name,
                this.ObjectClassName,
                this.PersistenceMode,
                this.Value == null ? null : this.Value
                    .Where(kvp => !persistedChildrenOnly || kvp.Value.PersistenceMode == PersistenceMode.Persisted)
                    .ToDictionary(k => k.Key, v => v.Value.Copy(persistedChildrenOnly)));
        }
    }
}
