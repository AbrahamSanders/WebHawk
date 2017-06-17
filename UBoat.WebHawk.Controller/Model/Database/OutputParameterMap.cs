using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Model.Database
{
    [Serializable]
    public class OutputParameterMap
    {
        public OutputParameterType ParameterType { get; set; }
        public string ParameterName { get; set; }
        public string StateVariable { get; set; }
        public XMLFieldOutputMode XMLFieldOutputMode { get; set; }
        public PersistenceMode PersistenceMode { get; set; }

        public OutputParameterMap Clone()
        {
            return (OutputParameterMap)this.MemberwiseClone();
        }
    }
}
