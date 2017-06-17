using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.Validation
{
    public class ValidationMessage
    {
        public ValidationMessageLevel Level { get; set; }
        public string Message { get; set; }

        public ValidationMessage(ValidationMessageLevel level, string message)
        {
            this.Level = level;
            this.Message = message;
        }
    }

    public enum ValidationMessageLevel
    {
        Fail,
        Warning,
        Info
    }
}
