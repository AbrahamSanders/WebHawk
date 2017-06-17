using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess.Metadata
{
    public abstract class SchemaObject : MetadataBase
    {
        public string Schema { get; set; }
    }
}
