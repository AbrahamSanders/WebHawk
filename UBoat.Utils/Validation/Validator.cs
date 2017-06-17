using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBoat.Utils.Validation
{
    public static class Validator
    {
        public static ValidationResult Validate(params IValidatable[] itemsToValidate)
        {
            ValidationResult masterResult = new ValidationResult(true);
            foreach (IValidatable item in itemsToValidate)
            {
                if (item != null)
                {
                    ValidationResult itemResult = item.PerformValidation();
                    masterResult.Append(itemResult);
                }
            }
            return masterResult;
        }

        public static bool ValidateWithPrompt(string promptTitle, params IValidatable[] itemsToValidate)
        {
            ValidationResult result = Validate(itemsToValidate);
            StringBuilder sb = new StringBuilder();
            if (!result.IsValid)
            {
                IEnumerable<ValidationMessage> failedMessages = result.Messages.Where(msg => msg.Level == ValidationMessageLevel.Fail);
                if (failedMessages.Any())
                {
                    zCompileMessageList(sb, failedMessages);
                }
                else
                {
                    sb.Append("Validation failed.");
                }
                MessageBox.Show(sb.ToString(), promptTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                IEnumerable<ValidationMessage> warningMessages = result.Messages.Where(msg => msg.Level == ValidationMessageLevel.Warning);
                bool proceed = true;
                if (warningMessages.Any())
                {
                    zCompileMessageList(sb, warningMessages);
                    sb.Append(" Would you like to continue?");
                    proceed = MessageBox.Show(sb.ToString(), promptTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                    sb.Clear();
                }
                if (proceed)
                {
                    IEnumerable<ValidationMessage> infoMessages = result.Messages.Where(msg => msg.Level == ValidationMessageLevel.Info);
                    if (infoMessages.Any())
                    {
                        zCompileMessageList(sb, infoMessages);
                        MessageBox.Show(sb.ToString(), promptTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                return proceed;
            }
        }

        private static void zCompileMessageList(StringBuilder sb, IEnumerable<ValidationMessage> messages)
        {
            if (messages.Count() == 1)
            {
                sb.Append(messages.First().Message);
            }
            else
            {
                foreach (ValidationMessage message in messages)
                {
                    sb.AppendFormat("- {0}", message.Message);
                    sb.AppendLine();
                }
            }
        }
    }
}
