using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess.Metadata
{
    public class ProcedureParameter : SchemaObject
    {
        internal static ProcedureParameter FromRow(DataRow row)
        {
            return new ProcedureParameter()
            {
                Database = row.Field<string>("SPECIFIC_CATALOG"),
                Schema = row.Field<string>("SPECIFIC_SCHEMA"),
                ProcedureName = row.Field<string>("SPECIFIC_NAME"),
                Name = row.Field<string>("PARAMETER_NAME"),
                Position = row.Field<int>("ORDINAL_POSITION"),
                Direction = zGetParameterDirection(row.Field<string>("PARAMETER_MODE")),
                IsReturnValue = !row.IsNull("IS_RESULT") && row.Field<string>("IS_RESULT").ToUpper() == "YES",
                DataType = row.Field<string>("DATA_TYPE"),
                MaxLength = row.Field<int?>("CHARACTER_MAXIMUM_LENGTH"),
                NumericPrecision = !row.IsNull("NUMERIC_PRECISION") ? Convert.ToInt32(row.Field<byte>("NUMERIC_PRECISION")) : new int?()
            };
        }

        private static ParameterDirection zGetParameterDirection(string rowValue)
        {
            rowValue = rowValue != null ? rowValue.ToUpper() : String.Empty;
            switch (rowValue)
            {
                case "IN":
                    return ParameterDirection.Input;
                case "INOUT":
                    return ParameterDirection.InputOutput;
                case "OUT": //TODO: verify that this works.
                    return ParameterDirection.Output;
                case "RETURN": //TODO: verify that this works.
                    return ParameterDirection.ReturnValue;
                default:
                    return ParameterDirection.Input;
            }
        }

        public string ProcedureName { get; set; }
        public int Position { get; set; }
        public ParameterDirection Direction { get; set; }
        public bool IsReturnValue { get; set; }
        public string DataType { get; set; }
        public int? MaxLength { get; set; }
        public int? NumericPrecision { get; set; }
    }
}
