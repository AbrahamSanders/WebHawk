using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Database
{
    [Serializable]
    public class InputParameterMap
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public bool TrimVariableValueWhitespace { get; set; }

        public InputParameterMap Clone()
        {
            return (InputParameterMap)this.MemberwiseClone();
        }
    }
}
