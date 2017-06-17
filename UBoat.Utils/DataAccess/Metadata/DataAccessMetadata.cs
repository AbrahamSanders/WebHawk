using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.DataAccess.Metadata
{
    public class DataAccessMetadata
    {
        public List<Table> Tables { get; set; }
        public List<Column> TableColumns { get; set; }
        public List<View> Views { get; set; }
        public List<Column> ViewColumns { get; set; }
        public List<Procedure> Procedures { get; set; }
        public List<ProcedureParameter> ProcedureParameters { get; set; }

        public DataAccessMetadata()
        {
            this.Tables = new List<Table>();
            this.TableColumns = new List<Column>();
            this.Views = new List<View>();
            this.ViewColumns = new List<Column>();
            this.Procedures = new List<Procedure>();
            this.ProcedureParameters = new List<ProcedureParameter>();
        }
    }
}
