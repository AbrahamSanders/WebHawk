using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess.Metadata
{
    public class Table : SchemaObject
    {
        internal static Table FromRow(DataRow row)
        {
            return new Table()
            {
                Database = row.Field<string>("TABLE_CATALOG"),
                Schema = row.Field<string>("TABLE_SCHEMA"),
                Name = row.Field<string>("TABLE_NAME"),
                Type = row.Field<string>("TABLE_TYPE")
            };
        }

        public string Type { get; set; }
    }
}
