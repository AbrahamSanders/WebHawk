using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.Validation
{
    public class ValidationResult
    {
        public static ValidationResult WithFailure(string message)
        {
            return new ValidationResult(false,
                new ValidationMessage(ValidationMessageLevel.Fail, message));
        }
        public static ValidationResult WithWarning(string message)
        {
            return new ValidationResult(true,
                new ValidationMessage(ValidationMessageLevel.Warning, message));
        }
        public static ValidationResult WithInfo(string message)
        {
            return new ValidationResult(true,
                new ValidationMessage(ValidationMessageLevel.Info, message));
        }

        public bool IsValid { get; set; }
        public List<ValidationMessage> Messages { get; set; }

        public ValidationResult(bool isValid, params ValidationMessage[] messages)
        {
            this.IsValid = isValid;
            this.Messages = new List<ValidationMessage>();
            this.Messages.AddRange(messages);
        }

        public void Append(ValidationResult validationResult)
        {
            this.IsValid = this.IsValid && validationResult.IsValid;
            this.Messages.AddRange(validationResult.Messages);
        }
    }
}
