using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.Utils.DataAccess.MySql;
using UBoat.Utils.DataAccess.ODBC;
using UBoat.Utils.DataAccess.OleDb;
using UBoat.Utils.DataAccess.SQL;
using UBoat.Utils.DataAccess.SQLite;

namespace UBoat.Utils.DataAccess
{
    public static class DataAccessFactory
    {
        public static IDataAccess CreateDataAccess(DataAccessType dataAccessType, string connectionString)
        {
            switch (dataAccessType)
            {
                case DataAccessType.SQLite:
                    return new SQLiteDataAccess(connectionString);
                case DataAccessType.SQL:
                    return new SQLDataAccess(connectionString);
                case DataAccessType.MySql:
                    return new MySqlDataAccess(connectionString);
                case DataAccessType.OleDb:
                    return new OleDbDataAccess(connectionString);
                case DataAccessType.ODBC:
                    return new ODBCDataAccess(connectionString);
                default:
                    throw new NotSupportedException();
            }
        }

        public static DbConnectionStringBuilder GetConnectionStringBuilder(DataAccessType dataAccessType)
        {
            switch (dataAccessType)
            {
                case DataAccessType.SQLite:
                    return new SQLiteConnectionStringBuilder();
                case DataAccessType.SQL:
                    return new SqlConnectionStringBuilder();
                case DataAccessType.MySql:
                    return new MySqlConnectionStringBuilder();
                case DataAccessType.OleDb:
                    return new OleDbConnectionStringBuilder();
                case DataAccessType.ODBC:
                    return new OdbcConnectionStringBuilder();
                default:
                    throw new NotSupportedException();
            }
        }

        public static DataAccessProperties GetDataAccessProperties(DataAccessType dataAccessType)
        {
            switch (dataAccessType)
            {
                case DataAccessType.SQLite:
                    return new DataAccessProperties(false, true);
                default:
                    return new DataAccessProperties(true, true);
            }
        }
    }
}
