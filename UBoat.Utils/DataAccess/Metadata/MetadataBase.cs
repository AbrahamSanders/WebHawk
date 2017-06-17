using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess.Metadata
{
    public abstract class MetadataBase
    {
        public string Database { get; set; }
        public string Name { get; set; }
    }
}
