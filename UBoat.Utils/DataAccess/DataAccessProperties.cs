using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess
{
    public class DataAccessProperties
    {
        public bool SupportsStoredProcedures { get; private set; }
        public bool SupportsInformationSchema { get; private set; }

        public DataAccessProperties(bool supportsStoredProcedures, bool supportsInformationSchema)
        {
            this.SupportsStoredProcedures = supportsStoredProcedures;
            this.SupportsInformationSchema = supportsInformationSchema;
        }
    }
}
