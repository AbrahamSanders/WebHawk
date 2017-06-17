using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Database;

namespace UBoat.WebHawk.UI.StepEditors.DatabaseEditors
{
    public static class ResultMappingEditorFactory
    {
        public static StepEditor GetResultMappingEditor(StepEditContext context, ResultMapping resultMapping)
        {
            if (resultMapping is ScalarResultMapping)
            {
                return new ScalarResultMappingEditor(context, (ScalarResultMapping)resultMapping);
            }
            if (resultMapping is TableResultMapping)
            {
                return new TableResultMappingEditor(context, (TableResultMapping)resultMapping);
            }

            throw new NotSupportedException();
        }
    }
}
