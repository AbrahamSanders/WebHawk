using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace UBoat.Utils.DataAccess.MySql
{
    /// <summary>
    /// Data access abstraction class for working with MySql databases.
    /// </summary>
    internal class MySqlDataAccess : DataAccessBase<MySqlConnection, MySqlCommand>
    {
        #region Public Properties

        public override DataAccessType DataAccessType
        {
            get
            {
                return DataAccessType.MySql;
            }
        }

        #endregion

        #region Constructors

        public MySqlDataAccess(string connectionString)
            : base(connectionString) { }

        #endregion

        #region Private Methods

        protected override MySqlConnection CreateConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }

        protected override MySqlCommand CreateCommand(CommandType commandType, string commandText)
        {
            MySqlCommand comm = new MySqlCommand(commandText, m_Connection);
            comm.CommandType = commandType == CommandType.StoredProcedure 
                ? System.Data.CommandType.StoredProcedure 
                : System.Data.CommandType.Text;
            return comm;
        }

        protected override DbDataAdapter CreateAdapter(MySqlCommand command)
        {
            return new MySqlDataAdapter(command);
        }

        protected override string GetMetadataCollectionName(DataAccessMetadataType metadataType)
        {
            //NOTE: MySql.Data.MySqlClient does not provide the MetaDataCollectionNames class, so the strings are hardcoded here instead.
            //      The supported strings are documented at http://dev.mysql.com/doc/connector-net/en/connector-net-programming-getschema-collections.html,
            //      but for some reason the Connector/Net developers missed the boat on this class that seems to exist in every other ADO.NET provider.
            //      Oh well, life sucks. Whatcha gonna do...
            switch (metadataType)
            {
                case DataAccessMetadataType.Tables:
                    return "Tables";
                case DataAccessMetadataType.TableColumns:
                    return "Columns";
                case DataAccessMetadataType.Views:
                    return "Views";
                case DataAccessMetadataType.ViewColumns:
                    return "ViewColumns";
                case DataAccessMetadataType.Procedures:
                    return "Procedures";
                case DataAccessMetadataType.ProcedureParameters:
                    return "Procedure Parameters";
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
                        database, schema, schemaObject, "PROCEDURE", schemaSubObject
                    };
                default:
                    throw new NotSupportedException();
            }
        }

        #endregion
    }
}
