using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess.Metadata
{
    public class View : SchemaObject
    {
        internal static View FromRow(DataRow row)
        {
            return new View()
            {
                Database = row.Field<string>("TABLE_CATALOG"),
                Schema = row.Field<string>("TABLE_SCHEMA"),
                Name = row.Field<string>("TABLE_NAME"),
                IsUpdatable = !row.IsNull("IS_UPDATABLE") && row.Field<string>("IS_UPDATABLE").ToUpper() == "YES"
            };
        }

        public bool IsUpdatable { get; set; }
    }
}
