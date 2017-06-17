using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UBoat.WebHawk.Controller.Model.Conditional;

namespace UBoat.WebHawk.Controller.Conditional
{
    internal class NumericExpressionEvaluator : ExpressionEvaluatorBase<decimal>
    {
        protected override bool zEvaluateExpression(ExpressionNode expression, decimal value1, decimal value2)
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

        protected override bool zGetTypeData(string str, out decimal value)
        {
            str = Regex.Replace(str, "[^0-9.]", string.Empty);
            return Decimal.TryParse(str, out value);
        }

        protected override FormatException zGetFormatException(string value)
        {
            return new FormatException(String.Format("Cannot extract numeric value from text \"{0}\".", value));
        }
    }
}
