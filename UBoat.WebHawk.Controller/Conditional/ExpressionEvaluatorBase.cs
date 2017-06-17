using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.WebHawk.Controller.Model.Conditional;

namespace UBoat.WebHawk.Controller.Conditional
{
    internal abstract class ExpressionEvaluatorBase<T> : IExpressionEvaluator
    {
        public bool EvaulateExpression(ExpressionNode expression, DataScope dataScope)
        {
            IStateVariable variable1 = dataScope.GetStateVariable(expression.StateVariable);
            if (variable1 == null)
            {
                throw zGetMissingVariableException(expression, false);
            }
            string strValue1 = variable1.ValueAsString();
            T value1;
            if (!zGetTypeData(strValue1, out value1))
            {
                throw zGetFormatException(strValue1);
            }

            string strValue2;
            if (expression.VariableAsValue)
            {
                IStateVariable variable2 = dataScope.GetStateVariable(expression.Value);
                if (variable2 == null)
                {
                    throw zGetMissingVariableException(expression, true);
                }
                strValue2 = variable2.ValueAsString();
            }
            else
            {
                strValue2 = expression.Value;
            }
            T value2;
            if (!zGetTypeData(strValue2, out value2))
            {
                throw zGetFormatException(strValue2);
            }

            bool result = zEvaluateExpression(expression, value1, value2);
            return expression.Negated ? !result : result;
        }

        private ArgumentException zGetMissingVariableException(ExpressionNode expression, bool forValueVariable)
        {
            return new ArgumentException(String.Format("Could not evaluate expression \"{0}\" for variable \"{1}\": could not find {2} in data scope.",
                        expression.GetDescription(),
                        expression.StateVariable,
                        forValueVariable ? "value variable" : "expression variable"));
        }

        protected abstract bool zEvaluateExpression(ExpressionNode expression, T value1, T value2);
        protected abstract bool zGetTypeData(string str, out T value);
        protected abstract FormatException zGetFormatException(string value);
    }
}
