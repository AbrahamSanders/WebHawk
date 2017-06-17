using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess
{
    public class ParameterBuilder
    {
        private DbCommand m_Command;

        public ParameterBuilder(DbCommand command)
        {
            m_Command = command;
        }

        public DbParameter CreateParameter(string paramName, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            DbParameter parameter = m_Command.CreateParameter();
            parameter.ParameterName = paramName;
            parameter.Value = value;
            parameter.Direction = direction;
            return parameter;
        }
        public DbParameter CreateParameter(string paramName, DbType type, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            DbParameter parameter = CreateParameter(paramName, value, direction);
            parameter.DbType = type;
            return parameter;
        }
        public DbParameter CreateParameter(string paramName, DbType type, int size, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            DbParameter parameter = CreateParameter(paramName, type, value, direction);
            parameter.Size = size;
            return parameter;
        }
    }
}
