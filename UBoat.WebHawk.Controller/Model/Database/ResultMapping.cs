using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Model.Database
{
    [Serializable]
    public abstract class ResultMapping
    {
        public PersistenceMode PersistenceMode { get; set; }
    }
}
