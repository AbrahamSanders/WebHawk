using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess.OleDb
{
    /// <summary>
    /// Data access abstraction class for working with OleDb data sources.
    /// </summary>
    internal class OleDbDataAccess : DataAccessBase<OleDbConnection, OleDbCommand>
    {
        #region Public Properties

        public override DataAccessType DataAccessType
        {
            get
            {
                return DataAccessType.OleDb;
            }
        }

        #endregion

        #region Constructors

        public OleDbDataAccess(string connectionString)
            : base(connectionString) { }

        #endregion

        #region Private Methods

        protected override OleDbConnection CreateConnection(string connectionString)
        {
            return new OleDbConnection(connectionString);
        }

        protected override OleDbCommand CreateCommand(CommandType commandType, string commandText)
        {
            OleDbCommand comm = new OleDbCommand(commandText, m_Connection);
            comm.CommandType = commandType == CommandType.StoredProcedure 
                ? System.Data.CommandType.StoredProcedure 
                : System.Data.CommandType.Text;
            return comm;
        }

        protected override DbDataAdapter CreateAdapter(OleDbCommand command)
        {
            return new OleDbDataAdapter(command);
        }

        protected override string GetMetadataCollectionName(DataAccessMetadataType metadataType)
        {
            switch (metadataType)
            {
                case DataAccessMetadataType.Tables:
                    return OleDbMetaDataCollectionNames.Tables;
                case DataAccessMetadataType.TableColumns:
                    return OleDbMetaDataCollectionNames.Columns;
                case DataAccessMetadataType.Views:
                    return OleDbMetaDataCollectionNames.Views;
                case DataAccessMetadataType.ViewColumns:
                    return OleDbMetaDataCollectionNames.Columns;
                case DataAccessMetadataType.Procedures:
                    return OleDbMetaDataCollectionNames.Procedures;
                case DataAccessMetadataType.ProcedureParameters:
                    return OleDbMetaDataCollectionNames.ProcedureParameters;
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
