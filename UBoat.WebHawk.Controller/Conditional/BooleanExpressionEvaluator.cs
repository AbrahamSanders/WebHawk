using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UBoat.WebHawk.Controller.Model.Conditional;

namespace UBoat.WebHawk.Controller.Conditional
{
    internal class BooleanExpressionEvaluator : ExpressionEvaluatorBase<bool>
    {
        protected override bool zEvaluateExpression(ExpressionNode expression, bool value1, bool value2)
        {
            switch (expression.ComparativeOperator)
            {
                case Comparative.Equals:
                    return value1 == value2;
                default:
                    throw new NotSupportedException();
            }
        }

        protected override bool zGetTypeData(string str, out bool value)
        {
            str = Regex.Replace(str, "TODO: Boolean regex here", string.Empty);
            return bool.TryParse(str, out value);
        }

        protected override FormatException zGetFormatException(string value)
        {
            return new FormatException(String.Format("Cannot extract true/false value from text \"{0}\".", value));
        }
    }
}
