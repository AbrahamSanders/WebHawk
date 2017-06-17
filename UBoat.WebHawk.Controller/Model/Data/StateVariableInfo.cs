using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Data
{
    [Serializable]
    public class StateVariableInfo : IEquatable<StateVariableInfo>
    {
        public StateVariableInfo()
        {
        }
        public StateVariableInfo(string stateVariableName, DataType dataType, PersistenceMode persistenceMode)
        {
            this.StateVariableName = stateVariableName;
            this.DataType = dataType;
            this.PersistenceMode = persistenceMode;
        }

        public string StateVariableName { get; set; }
        public DataType DataType { get; set; }
        public PersistenceMode PersistenceMode { get; set; }

        public override string ToString()
        {
            return String.Format("{0} ({1})", this.StateVariableName, this.DataType);
        }

        public bool Equals(StateVariableInfo other)
        {
            return this.StateVariableName == other.StateVariableName;
        }
    }
}
