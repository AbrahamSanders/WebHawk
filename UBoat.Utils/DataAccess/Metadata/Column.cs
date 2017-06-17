using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess.Metadata
{
    public class Column : SchemaObject
    {
        internal static Column FromRow(DataRow row)
        {
            return new Column()
            {
                Database = row.Field<string>("TABLE_CATALOG"),
                Schema = row.Field<string>("TABLE_SCHEMA"),
                TableName = row.Field<string>("TABLE_NAME"),
                Name = row.Field<string>("COLUMN_NAME"),
                Position = row.Field<int>("ORDINAL_POSITION"),
                IsNullable = !row.IsNull("IS_NULLABLE") && row.Field<string>("IS_NULLABLE").ToUpper() == "YES",
                DataType = row.Field<string>("DATA_TYPE"),
                DefaultValue = row.Field<string>("COLUMN_DEFAULT"),
                MaxLength = row.Field<int?>("CHARACTER_MAXIMUM_LENGTH"),
                NumericPrecision = !row.IsNull("NUMERIC_PRECISION") ? Convert.ToInt32(row.Field<byte>("NUMERIC_PRECISION")) : new int?()
            };
        }

        public string TableName { get; set; }
        public int Position { get; set; }
        public bool IsNullable { get; set; }
        public string DataType { get; set; }
        public string DefaultValue { get; set; }
        public int? MaxLength { get; set; }
        public int? NumericPrecision { get; set; }
    }
}
