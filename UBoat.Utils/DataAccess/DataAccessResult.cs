using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess
{
    public class DataAccessResult<T> : DataAccessResult
    {
        public T Value { get; private set; }

        public DataAccessResult(T value) 
            : this(null, value)
        {
        }
        public DataAccessResult(IEnumerable<DbParameter> outputParameters, T value) 
            : base(outputParameters)
        {
            this.Value = value;
        }
    }

    public class DataAccessResult
    {
        public IEnumerable<DbParameter> OutputParameters { get; private set; }

        public DataAccessResult() 
            : this(null)
        {
        }
        public DataAccessResult(IEnumerable<DbParameter> outputParameters)
        {
            this.OutputParameters = outputParameters;
        }
    }
}
