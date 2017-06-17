using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess.Metadata
{
    public class Procedure : SchemaObject
    {
        internal static Procedure FromRow(DataRow row)
        {
            return new Procedure()
            {
                Database = row.Field<string>("ROUTINE_CATALOG"),
                Schema = row.Field<string>("ROUTINE_SCHEMA"),
                Name = row.Field<string>("ROUTINE_NAME"),
                Type = row.Field<string>("ROUTINE_TYPE"),
                Definition = row.Field<string>("ROUTINE_DEFINITION")
            };
        }

        public string Definition { get; set; }
        public string Type { get; set; }
    }
}
