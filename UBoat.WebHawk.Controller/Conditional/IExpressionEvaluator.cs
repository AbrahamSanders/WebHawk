using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.WebHawk.Controller.Model.Conditional;

namespace UBoat.WebHawk.Controller.Conditional
{
    internal interface IExpressionEvaluator
    {
        bool EvaulateExpression(ExpressionNode expression, DataScope dataScope);
    }
}
