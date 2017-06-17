using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UBoat.Utils.DataAccess.SQLite
{
    internal class SQLiteStoredProcProvider
    {
        private string m_StoredProcBasePath;

        public SQLiteStoredProcProvider(string dbPath)
        {
            m_StoredProcBasePath = Path.GetDirectoryName(dbPath);
        }

        public string GetStoredProcedure(string procedureName)
        {
            string fileName = Path.Combine(m_StoredProcBasePath, String.Format("StoredProcedures\\{0}.sql", procedureName));
            if (!File.Exists(fileName))
            {
                throw new ArgumentException(String.Format("A stored procedure with the name \"{0}\" does not exist.", procedureName));
            }
            return File.ReadAllText(fileName);
        }
    }
}
