using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess.SQL
{
    /// <summary>
    /// Data access abstraction class for working with SQL Server databases.
    /// </summary>
    internal class SQLDataAccess : DataAccessBase<SqlConnection, SqlCommand>
    {
        #region Public Properties

        public override DataAccessType DataAccessType
        {
            get
            {
                return DataAccessType.SQL;
            }
        }

        #endregion

        #region Constructors

        public SQLDataAccess(string connectionString)
            : base(connectionString) { }

        #endregion

        #region Private Methods

        protected override SqlConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        protected override SqlCommand CreateCommand(CommandType commandType, string commandText)
        {
            SqlCommand comm = new SqlCommand(commandText, m_Connection);
            comm.CommandType = commandType == CommandType.StoredProcedure 
                ? System.Data.CommandType.StoredProcedure 
                : System.Data.CommandType.Text;
            return comm;
        }

        protected override DbDataAdapter CreateAdapter(SqlCommand command)
        {
            return new SqlDataAdapter(command);
        }

        protected override string GetMetadataCollectionName(DataAccessMetadataType metadataType)
        {
            switch (metadataType)
            {
                case DataAccessMetadataType.Tables:
                    return SqlClientMetaDataCollectionNames.Tables;
                case DataAccessMetadataType.TableColumns:
                    return SqlClientMetaDataCollectionNames.Columns;
                case DataAccessMetadataType.Views:
                    return SqlClientMetaDataCollectionNames.Views;
                case DataAccessMetadataType.ViewColumns:
                    return SqlClientMetaDataCollectionNames.ViewColumns;
                case DataAccessMetadataType.Procedures:
                    return SqlClientMetaDataCollectionNames.Procedures;
                case DataAccessMetadataType.ProcedureParameters:
                    //return SqlClientMetaDataCollectionNames.Parameters;
                    return "ProcedureParameters"; //Apparently, the built in value "Parameters" does not work but this does...
                default:
                    throw new NotSupportedException();
            }
        }

        protected override string[] GetMetadataRestrictions(DataAccessMetadataType metadataType, string database, string schema, string schemaObject, string schemaSubObject)
        {
            switch (metadataType)
            {
                case DataAccessMetadataType.Tables:
                    return new string[]
                    {
                        database, schema, schemaObject, "BASE TABLE"
                    };
                case DataAccessMetadataType.TableColumns:
                    return new string[]
                    {
                        database, schema, schemaObject, schemaSubObject
                    };
                case DataAccessMetadataType.Views:
                    return new string[]
                    {
                        database, schema, schemaObject
                    };
                case DataAccessMetadataType.ViewColumns:
                    return new string[]
                    {
                        database, schema, schemaObject, schemaSubObject
                    };
                case DataAccessMetadataType.Procedures:
                    return new string[]
                    {
                        database, schema, schemaObject, "PROCEDURE"
                    };
                case DataAccessMetadataType.ProcedureParameters:
                    return new string[]
                    {
                        database, schema, schemaObject, schemaSubObject
                    };
                default:
                    throw new NotSupportedException();
            }
        }

        #endregion
    }
}
