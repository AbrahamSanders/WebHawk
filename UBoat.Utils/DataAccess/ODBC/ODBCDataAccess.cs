using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess.ODBC
{
    /// <summary>
    /// Data access abstraction class for working with ODBC data sources.
    /// </summary>
    internal class ODBCDataAccess : DataAccessBase<OdbcConnection, OdbcCommand>
    {
        #region Public Properties

        public override DataAccessType DataAccessType
        {
            get
            {
                return DataAccessType.ODBC;
            }
        }

        #endregion

        #region Constructors

        public ODBCDataAccess(string connectionString)
            : base(connectionString) { }

        #endregion

        #region Private Methods

        protected override OdbcConnection CreateConnection(string connectionString)
        {
            return new OdbcConnection(connectionString);
        }

        protected override OdbcCommand CreateCommand(CommandType commandType, string commandText)
        {
            OdbcCommand comm = new OdbcCommand(commandText, m_Connection);
            comm.CommandType = commandType == CommandType.StoredProcedure
                ? System.Data.CommandType.StoredProcedure
                : System.Data.CommandType.Text;
            return comm;
        }

        protected override DbDataAdapter CreateAdapter(OdbcCommand command)
        {
            return new OdbcDataAdapter(command);
        }

        protected override string GetMetadataCollectionName(DataAccessMetadataType metadataType)
        {
            switch (metadataType)
            {
                case DataAccessMetadataType.Tables:
                    return OdbcMetaDataCollectionNames.Tables;
                case DataAccessMetadataType.TableColumns:
                    return OdbcMetaDataCollectionNames.Columns;
                case DataAccessMetadataType.Views:
                    return OdbcMetaDataCollectionNames.Views;
                case DataAccessMetadataType.ViewColumns:
                    return OdbcMetaDataCollectionNames.Columns;
                case DataAccessMetadataType.Procedures:
                    return OdbcMetaDataCollectionNames.Procedures;
                case DataAccessMetadataType.ProcedureParameters:
                    return OdbcMetaDataCollectionNames.ProcedureParameters;
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
