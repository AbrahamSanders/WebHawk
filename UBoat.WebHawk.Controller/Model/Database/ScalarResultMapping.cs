using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Model.Database
{
    [Serializable]
    public class ScalarResultMapping : ResultMapping
    {
        public string StateVariable { get; set; }
        public XMLFieldOutputMode XMLFieldOutputMode { get; set; }
    }
}
