using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.Utils.DataAccess;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.WebHawk.Controller.Model.Database;

namespace UBoat.WebHawk.Controller.Model.Automation.Steps
{
    [Serializable]
    public class DatabaseStep : Step
    {
        public DataAccessType ConnectionType { get; set; }
        public string ConnectionString { get; set; }

        public CommandType CommandType { get; set; }
        public string Command { get; set; }
        public bool TrimVariableValueWhitespace { get; set; }
        
        public List<InputParameterMap> InputParameterMapping { get; set; }
        public List<OutputParameterMap> OutputParameterMapping { get; set; }
        public ResultMapping ResultMapping { get; set; }

        public DatabaseStep()
        {
            this.InputParameterMapping = new List<InputParameterMap>();
            this.OutputParameterMapping = new List<OutputParameterMap>();
            this.TrimVariableValueWhitespace = true;
        }

        protected override string get_DisplayNameImpl()
        {
            return "Database";
        }
    }
}
