using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace UBoat.Utils.DataAccess.SQLite
{
    /// <summary>
    /// Data access abstraction class for working with SQLite database files.
    /// </summary>
    internal class SQLiteDataAccess : DataAccessBase<SQLiteConnection, SQLiteCommand>
    {
        #region Private Members

        private SQLiteStoredProcProvider m_StoredProcProvider;
        //TODO: investigate best practices for dealing with concurrent SQLite write operations.
        //This lock will only work within the scope of a single process.
        private static readonly object m_Lock = new object();

        #endregion

        #region Public Properties

        public override DataAccessType DataAccessType
        {
            get 
            { 
                return DataAccessType.SQLite;
            }
        }

        #endregion

        #region Constructors

        public SQLiteDataAccess(string connectionString)
            : base(connectionString)
        {
            SQLiteConnectionStringBuilder connStrBuilder = new SQLiteConnectionStringBuilder(connectionString);
            m_StoredProcProvider = new SQLiteStoredProcProvider(connStrBuilder.DataSource);
        }

        #endregion

        #region Public Methods

        public override DataAccessResult ExecuteQueryReader(CommandType commandType, string query, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder, Action<DataReaderHelper> readerAction)
        {
            lock (m_Lock)
            {
                return base.ExecuteQueryReader(commandType, query, transaction, paramBuilder, readerAction);
            }
        }

        public override DataAccessResult<DataTable> ExecuteQueryDataTable(CommandType commandType, string query, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder)
        {
            lock (m_Lock)
            {
                return base.ExecuteQueryDataTable(commandType, query, transaction, paramBuilder);
            }
        }

        public override DataAccessResult ExecuteNonQuery(CommandType commandType, string nonQuery, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder)
        {
            lock (m_Lock)
            {
                return base.ExecuteNonQuery(commandType, nonQuery, transaction, paramBuilder);
            }
        }

        public override DataAccessResult<object> ExecuteScalar(CommandType commandType, string query, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder)
        {
            lock (m_Lock)
            {
                return base.ExecuteScalar(commandType, query, transaction, paramBuilder);
            }
        }

        public override DbTransaction BeginTransaction()
        {
            lock (m_Lock)
            {
                return base.BeginTransaction();
            }
        }

        public override void CommitTransaction(DbTransaction transaction)
        {
            lock (m_Lock)
            {
                base.CommitTransaction(transaction);
            }
        }

        public override void RollbackTransaction(DbTransaction transaction)
        {
            lock (m_Lock)
            {
                base.RollbackTransaction(transaction);
            }
        }

        public override void Dispose()
        {
            lock (m_Lock)
            {
                base.Dispose();
            }
        }

        #endregion

        #region Private Methods

        protected override SQLiteConnection CreateConnection(string connectionString)
        {
            return new SQLiteConnection(connectionString);
        }

        protected override SQLiteCommand CreateCommand(CommandType commandType, string commandText)
        {
            SQLiteCommand comm = new SQLiteCommand(m_Connection);
            comm.CommandType = System.Data.CommandType.Text;
            if (commandType == CommandType.StoredProcedure)
            {
                comm.CommandText = m_StoredProcProvider.GetStoredProcedure(commandText);
            }
            else
            {
                comm.CommandText = commandText;
            }
            return comm;
        }

        protected override DbDataAdapter CreateAdapter(SQLiteCommand command)
        {
            return new SQLiteDataAdapter(command);
        }

        protected override string GetMetadataCollectionName(DataAccessMetadataType metadataType)
        {
            switch (metadataType)
            {
                case DataAccessMetadataType.Tables:
                    return SQLiteMetaDataCollectionNames.Tables;
                case DataAccessMetadataType.TableColumns:
                    return SQLiteMetaDataCollectionNames.Columns;
                case DataAccessMetadataType.Views:
                    return SQLiteMetaDataCollectionNames.Views;
                case DataAccessMetadataType.ViewColumns:
                    return SQLiteMetaDataCollectionNames.ViewColumns;
                case DataAccessMetadataType.Procedures:
                    throw new NotSupportedException("SQLite does not natively support stored procedures.");
                case DataAccessMetadataType.ProcedureParameters:
                    throw new NotSupportedException("SQLite does not natively support stored procedures.");
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
                    throw new NotSupportedException("SQLite does not natively support stored procedures.");
                case DataAccessMetadataType.ProcedureParameters:
                    throw new NotSupportedException("SQLite does not natively support stored procedures.");
                default:
                    throw new NotSupportedException();
            }
        }

        #endregion
    }
}
