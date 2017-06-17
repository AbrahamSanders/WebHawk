using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UBoat.WebHawk.Controller.Model.Automation
{
    [Serializable]
    public class Sequence
    {
        public long SequenceId { get; set; }
        public string Name { get; set; }
        public SequenceType SequenceType { get; set; }
        public long StepCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
