using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Conditional
{
    internal static class ExpressionEvaluatorFactory
    {
        public static IExpressionEvaluator GetExpressionEvaulator(DataType dataType)
        {
            switch (dataType)
            {
                case DataType.String:
                    return new StringExpressionEvaluator();
                case DataType.Numeric:
                    return new NumericExpressionEvaluator();
                case DataType.DateTime:
                    return new DateTimeExpressionEvaluator();
                case DataType.Boolean:
                    return new BooleanExpressionEvaluator();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
