using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UBoat.WebHawk.Controller.Model.Conditional;

namespace UBoat.WebHawk.Controller.Conditional
{
    internal class StringExpressionEvaluator : ExpressionEvaluatorBase<string>
    {
        protected override bool zEvaluateExpression(ExpressionNode expression, string value1, string value2)
        {
            if (expression.ComparativeOperator != Comparative.RegexMatch && !expression.CaseSensitive)
            {
                value1 = value1.ToLower();
                value2 = value2.ToLower();
            }
            switch (expression.ComparativeOperator)
            {
                case Comparative.Equals:
                    return value1 == value2;
                case Comparative.BeginsWith:
                    return value1.StartsWith(value2);
                case Comparative.EndsWith:
                    return value1.EndsWith(value2);
                case Comparative.Contains:
                    return value1.Contains(value2);
                case Comparative.RegexMatch:
                    return Regex.IsMatch(value1, value2, expression.CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase);
                default:
                    throw new NotSupportedException();
            }
        }

        protected override bool zGetTypeData(string str, out string value)
        {
            value = str;
            return true;
        }

        protected override FormatException zGetFormatException(string value)
        {
            //This method will never be called because zGetTypeData will always return true for strings ;)
            throw new NotImplementedException();
        }
    }
}
