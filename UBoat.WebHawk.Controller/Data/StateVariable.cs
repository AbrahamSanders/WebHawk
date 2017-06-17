using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Data
{
    [Serializable]
    public class StateVariable<T> : IStateVariable
    {
        public string Name { get; set; }
        public DataType DataType { get; set; }
        public XMLFieldOutputMode XMLFieldOutputMode { get; protected set; }
        public PersistenceMode PersistenceMode { get; protected set; }
        public T Value { get; set; }

        public StateVariable(string name, DataType dataType, XMLFieldOutputMode xmlFieldOutputMode, PersistenceMode persistenceMode, T value)
        {
            this.Name = name;
            this.DataType = dataType;
            this.XMLFieldOutputMode = xmlFieldOutputMode;
            this.PersistenceMode = persistenceMode;
            this.Value = value;
        }

        public virtual string ValueAsString()
        {
            return Convert.ToString(Value);
        }

        public virtual IStateVariable Copy(bool persistedChildrenOnly = false)
        {
            return new StateVariable<T>(
                this.Name,
                this.DataType,
                this.XMLFieldOutputMode,
                this.PersistenceMode,
                this.Value);
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Name, this.ValueAsString());
        }
    }
}
