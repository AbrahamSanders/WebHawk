using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Model.Database
{
    [Serializable]
    public class TableResultMap
    {
        public string ColumnName { get; set; }
        public string StateVariable { get; set; }
        public XMLFieldOutputMode XMLFieldOutputMode { get; set; }
        public PersistenceMode PersistenceMode { get; set; }

        public TableResultMap Clone()
        {
            return (TableResultMap)this.MemberwiseClone();
        }
    }
}
