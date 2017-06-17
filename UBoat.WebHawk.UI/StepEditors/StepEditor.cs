using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils.Validation;

namespace UBoat.WebHawk.UI.StepEditors
{
    public class StepEditor : UserControl, IValidatable
    {
        public StepEditContext StepEditContext { get; set; }

        public virtual string Title
        {
            get
            {
                return "Step Editor (Override me!)";
            }
        }

        public virtual void SetContext(StepEditContext context)
        {
            this.StepEditContext = context;
        }

        public virtual void Save()
        {
            
        }

        public virtual ValidationResult PerformValidation()
        {
            ValidationResult result = new ValidationResult(true);
            return result;
        }
    }

    public class StepEditor<T> : StepEditor
    {
        protected T Target { get; set; }

        public virtual void SetContext(StepEditContext context, T target)
        {
            this.SetContext(context);
            this.Target = target;
        }
    }
}
