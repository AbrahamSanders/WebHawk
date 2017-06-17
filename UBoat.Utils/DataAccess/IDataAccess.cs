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
    public interface IDataAccess : IDisposable
    {
        DataAccessType DataAccessType { get; }
        DataAccessProperties DataAccessProperties { get; }

        DataAccessResult ExecuteQueryReader(CommandType commandType, string query, Action<DataReaderHelper> readerAction);
        DataAccessResult ExecuteQueryReader(CommandType commandType, string query, DbTransaction transaction, Action<DataReaderHelper> readerAction);
        DataAccessResult ExecuteQueryReader(CommandType commandType, string query, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder, Action<DataReaderHelper> readerAction);
        DataAccessResult ExecuteQueryReader(CommandType commandType, string query, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder, Action<DataReaderHelper> readerAction);

        DataAccessResult<DataTable> ExecuteQueryDataTable(CommandType commandType, string query);
        DataAccessResult<DataTable> ExecuteQueryDataTable(CommandType commandType, string query, DbTransaction transaction);
        DataAccessResult<DataTable> ExecuteQueryDataTable(CommandType commandType, string query, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder);
        DataAccessResult<DataTable> ExecuteQueryDataTable(CommandType commandType, string query, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder);

        DataAccessResult ExecuteNonQuery(CommandType commandType, string nonQuery);
        DataAccessResult ExecuteNonQuery(CommandType commandType, string nonQuery, DbTransaction transaction);
        DataAccessResult ExecuteNonQuery(CommandType commandType, string nonQuery, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder);
        DataAccessResult ExecuteNonQuery(CommandType commandType, string nonQuery, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder);

        DataAccessResult<object> ExecuteScalar(CommandType commandType, string query);
        DataAccessResult<object> ExecuteScalar(CommandType commandType, string query, DbTransaction transaction);
        DataAccessResult<object> ExecuteScalar(CommandType commandType, string query, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder);
        DataAccessResult<object> ExecuteScalar(CommandType commandType, string query, DbTransaction transaction, Func<ParameterBuilder, IEnumerable<DbParameter>> paramBuilder);

        DbTransaction BeginTransaction();
        void CommitTransaction(DbTransaction transaction);
        void RollbackTransaction(DbTransaction transaction);

        bool TestConnection(out string message);
        DataTable GetCollections();
        DataTable GetRestrictions();
        DataTable GetDataSourceInformation();
        DataAccessMetadata GetMetadata(DataAccessMetadataType metadataType, string database = null, string schema = null, string schemaObject = null, string schemaSubObject = null);
    }
}
