using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Database
{
    [Serializable]
    public class TableResultMapping : ResultMapping
    {
        public string ObjectSetListName { get; set; }
        public string ObjectSetClassName { get; set; }
        public bool IncludeInXML { get; set; }
        public List<TableResultMap> TableMapping { get; set; }

        public TableResultMapping()
        {
            this.TableMapping = new List<TableResultMap>();
        }
    }
}
