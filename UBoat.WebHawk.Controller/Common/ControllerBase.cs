using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Common
{
    public abstract class ControllerBase
    {
        #region Private Members

        private string m_ConnectionString;

        #endregion

        #region Public Properties

        public string ConnectionString
        {
            get
            {
                return m_ConnectionString;
            }
        }

        #endregion

        #region Constructor

        protected ControllerBase(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        #endregion
    }
}
