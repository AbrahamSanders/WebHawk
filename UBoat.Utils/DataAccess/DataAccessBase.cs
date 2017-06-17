using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using UBoat.Utils.DataAccess.Metadata;

namespace UBoat.Utils.DataAccess
{
    /// <summary>
    /// Base data access abstraction class. Override with provider-specific implementation.
    /// </summary>
    internal abstract class DataAccessBase<TConnection, TCommand> : IDataAccess 
        where TConnection : DbConnection 
        where TCommand : DbCommand
    {
        #region Private Members

        protected TConnection m_Connection;

        #endregion

        #region Public Properties

        public abstract DataAccessType DataAccessType
        {
            get;
        }

        public DataAccessProperties DataAccessProperties { get; private set; }

        #endregion

        #region Constructors

        protected DataAccessBase(string connectionString)
        {
            this.DataAccessProperties = DataAccessFactory.GetDataAccessProperties(this.DataAccessType);
            m_Connection = CreateConnection(connectionString);
        }

        #endregion

        #region Public Methods

        public DataAccessResult ExecuteQueryReader(CommandType commandType, string query, Action<DataReaderHelper> readerAction)
        {
            return ExecuteQueryReader(commandType, query, null, null, readerAction);
        }
        public DataAccessResult ExecuteQueryReader(CommandType commandType, string query, DbTransaction transaction, Action<DataReaderHelper> readerAction)
        {
            return ExecuteQueryReader(commandType, query, transaction, null, readerAction);
        }
        public DataAccessResult ExecuteQueryReader(CommandType commandType, string query, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder, Action<DataReaderHelper> readerAction)
        {
            return ExecuteQueryReader(commandType, query, null, paramBuilder, readerAction);
        }
        public virtual DataAccessResult ExecuteQueryReader(CommandType commandType, string query, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder, Action<DataReaderHelper> readerAction)
        {
            using (TCommand comm = CreateCommand(commandType, query))
            {
                zSetupForCommand(comm, transaction, paramBuilder);
                using (DataReaderHelper reader = new DataReaderHelper(comm.ExecuteReader()))
                {
                    readerAction(reader);
                }
                return new DataAccessResult(zGetOutputParameters(comm));
            }
        }

        public DataAccessResult<DataTable> ExecuteQueryDataTable(CommandType commandType, string query)
        {
            return ExecuteQueryDataTable(commandType, query, null, null);
        }
        public DataAccessResult<DataTable> ExecuteQueryDataTable(CommandType commandType, string query, DbTransaction transaction)
        {
            return ExecuteQueryDataTable(commandType, query, transaction, null);
        }
        public DataAccessResult<DataTable> ExecuteQueryDataTable(CommandType commandType, string query, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder)
        {
            return ExecuteQueryDataTable(commandType, query, null, paramBuilder);
        }
        public virtual DataAccessResult<DataTable> ExecuteQueryDataTable(CommandType commandType, string query, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder)
        {
            using (TCommand comm = CreateCommand(commandType, query))
            {
                zSetupForCommand(comm, transaction, paramBuilder);
                using (DbDataAdapter adapter = CreateAdapter(comm))
                {
                    using (DataSet ds = new DataSet())
                    {
                        adapter.Fill(ds);
                        DataTable tableResult = ds.Tables[0];
                        return new DataAccessResult<DataTable>(zGetOutputParameters(comm), tableResult);
                    }
                }
            }
        }

        public DataAccessResult ExecuteNonQuery(CommandType commandType, string nonQuery)
        {
            return ExecuteNonQuery(commandType, nonQuery, null, null);
        }
        public DataAccessResult ExecuteNonQuery(CommandType commandType, string nonQuery, DbTransaction transaction)
        {
            return ExecuteNonQuery(commandType, nonQuery, transaction, null);
        }
        public DataAccessResult ExecuteNonQuery(CommandType commandType, string nonQuery, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder)
        {
            return ExecuteNonQuery(commandType, nonQuery, null, paramBuilder);
        }
        public virtual DataAccessResult ExecuteNonQuery(CommandType commandType, string nonQuery, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder)
        {
            using (TCommand comm = CreateCommand(commandType, nonQuery))
            {
                zSetupForCommand(comm, transaction, paramBuilder);
                comm.ExecuteNonQuery();
                return new DataAccessResult(zGetOutputParameters(comm));
            }
        }

        public DataAccessResult<object> ExecuteScalar(CommandType commandType, string query)
        {
            return ExecuteScalar(commandType, query, null, null);
        }
        public DataAccessResult<object> ExecuteScalar(CommandType commandType, string query, DbTransaction transaction)
        {
            return ExecuteScalar(commandType, query, transaction, null);
        }
        public DataAccessResult<object> ExecuteScalar(CommandType commandType, string query, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder)
        {
            return ExecuteScalar(commandType, query, null, paramBuilder);
        }
        public virtual DataAccessResult<object> ExecuteScalar(CommandType commandType, string query, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder)
        {
            using (TCommand comm = CreateCommand(commandType, query))
            {
                zSetupForCommand(comm, transaction, paramBuilder);
                object scalarResult = comm.ExecuteScalar();
                return new DataAccessResult<object>(zGetOutputParameters(comm), scalarResult);
            }
        }

        public virtual DbTransaction BeginTransaction()
        {
            return m_Connection.BeginTransaction();
        }
        public virtual void CommitTransaction(DbTransaction transaction)
        {
            transaction.Commit();
        }
        public virtual void RollbackTransaction(DbTransaction transaction)
        {
            transaction.Rollback();
        }

        public bool TestConnection(out string message)
        {
            bool closeConnection = false;
            message = "Connection Successful!";
            try
            {
                if (m_Connection.State == ConnectionState.Open
                    || m_Connection.State == ConnectionState.Fetching
                    || m_Connection.State == ConnectionState.Executing)
                {
                    return true;
                }

                closeConnection = true;
                m_Connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                message = String.Format("Connection Unsuccessful: {0}", ex.Message);
                return false;
            }
            finally
            {
                if (closeConnection)
                {
                    try
                    {
                        if (m_Connection.State != ConnectionState.Closed)
                        {
                            m_Connection.Close();
                        }
                    }
                    catch { }
                }
            }
        }

        public DataAccessMetadata GetMetadata(DataAccessMetadataType metadataType, string database = null, string schema = null, string schemaObject = null, string schemaSubObject = null)
        {
            DataTable metadataTable = zGetMetadata(metadataType, database, schema, schemaObject, schemaSubObject);
            DataAccessMetadata metadata = new DataAccessMetadata();
            foreach (DataRow row in metadataTable.Rows)
            {
                switch (metadataType)
                {
                    case DataAccessMetadataType.Tables:
                        metadata.Tables.Add(Table.FromRow(row));
                        break;
                    case DataAccessMetadataType.TableColumns:
                        metadata.TableColumns.Add(Column.FromRow(row));
                        break;
                    case DataAccessMetadataType.Views:
                        metadata.Views.Add(View.FromRow(row));
                        break;
                    case DataAccessMetadataType.ViewColumns:
                        metadata.ViewColumns.Add(Column.FromRow(row));
                        break;
                    case DataAccessMetadataType.Procedures:
                        metadata.Procedures.Add(Procedure.FromRow(row));
                        break;
                    case DataAccessMetadataType.ProcedureParameters:
                        metadata.ProcedureParameters.Add(ProcedureParameter.FromRow(row));
                        break;
                }
            }
            return metadata;
        }

        public virtual void Dispose()
        {
            if (m_Connection != null)
            {
                m_Connection.Dispose();
            }
        }

        #endregion

        #region Private Methods

        protected abstract TConnection CreateConnection(string connectionString);
        protected abstract TCommand CreateCommand(CommandType commandType, string commandText);
        protected abstract DbDataAdapter CreateAdapter(TCommand command);
        protected abstract string GetMetadataCollectionName(DataAccessMetadataType metadataType);
        protected abstract string[] GetMetadataRestrictions(DataAccessMetadataType metadataType, string database, string schema, string schemaObject, string schemaSubObject);

        protected void zSetupForCommand(TCommand command, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> parameters)
        {
            if (parameters != null)
            {
                ParameterBuilder paramBuilder = new ParameterBuilder(command);
                IEnumerable<DbParameter> dbParams = parameters(paramBuilder);
                command.Parameters.AddRange(dbParams.ToArray());
            }

            if (m_Connection.State == ConnectionState.Closed)
            {
                m_Connection.Open();
            }
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
        }

        private IEnumerable<DbParameter> zGetOutputParameters(DbCommand command)
        {
            List<DbParameter> outputParameters = null;
            foreach (DbParameter parameter in command.Parameters)
            {
                if (parameter.Direction != ParameterDirection.Input)
                {
                    if (outputParameters == null)
                    {
                        outputParameters = new List<DbParameter>();
                    }
                    outputParameters.Add(parameter);
                }
            }
            return outputParameters;
        }

        private DataTable zGetMetadata(DataAccessMetadataType metadataType, string database, string schema, string schemaObject, string schemaSubObject)
        {
            string metadataCollectionName = GetMetadataCollectionName(metadataType);
            string[] restrictionValues = GetMetadataRestrictions(metadataType, database, schema, schemaObject, schemaSubObject);

            if (m_Connection.State == ConnectionState.Closed)
            {
                m_Connection.Open();
            }
            return m_Connection.GetSchema(metadataCollectionName, restrictionValues);
        }

        public DataTable GetCollections()
        {
            if (m_Connection.State == ConnectionState.Closed)
            {
                m_Connection.Open();
            }
            return m_Connection.GetSchema();
        }

        public DataTable GetRestrictions()
        {
            if (m_Connection.State == ConnectionState.Closed)
            {
                m_Connection.Open();
            }
            return m_Connection.GetSchema("Restrictions");
        }

        public DataTable GetDataSourceInformation()
        {
            if (m_Connection.State == ConnectionState.Closed)
            {
                m_Connection.Open();
            }
            return m_Connection.GetSchema("DataSourceInformation");
        }

        #endregion
    }
}
