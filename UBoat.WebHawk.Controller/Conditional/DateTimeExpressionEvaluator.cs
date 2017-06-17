using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UBoat.WebHawk.Controller.Model.Conditional;

namespace UBoat.WebHawk.Controller.Conditional
{
    internal class DateTimeExpressionEvaluator : ExpressionEvaluatorBase<DateTime>
    {
        protected override bool zEvaluateExpression(ExpressionNode expression, DateTime value1, DateTime value2)
        {
            switch (expression.ComparativeOperator)
            {
                case Comparative.Equals:
                    return value1 == value2;
                case Comparative.GreaterThan:
                    return value1 > value2;
                case Comparative.GreaterThanOrEquals:
                    return value1 >= value2;
                case Comparative.LessThan:
                    return value1 < value2;
                case Comparative.LessThanOrEquals:
                    return value1 <= value2;
                default:
                    throw new NotSupportedException();
            }
        }

        protected override bool zGetTypeData(string str, out DateTime value)
        {
            str = Regex.Replace(str, "TODO: DateTime regex here", string.Empty);
            return DateTime.TryParse(str, out value);
        }

        protected override FormatException zGetFormatException(string value)
        {
            return new FormatException(String.Format("Cannot extract date/time value from text \"{0}\".", value));
        }
    }
}
