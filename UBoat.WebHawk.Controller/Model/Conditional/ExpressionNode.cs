using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Model.Conditional
{
    [Serializable]
    public class ExpressionNode : ConditionNode
    {
        public string StateVariable { get; set; }
        public bool Negated { get; set; }
        public Comparative ComparativeOperator { get; set; }
        public string Value { get; set; }
        public bool VariableAsValue { get; set; }
        public bool CaseSensitive { get; set; }
        public DataType DataType { get; set; }

        public string GetDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Negated ? "Not " : string.Empty);
            switch (ComparativeOperator)
            {
                case Comparative.Equals:
                    sb.Append("Equal To ");
                    break;
                case Comparative.Contains:
                    sb.Append("Contains ");
                    break;
                case Comparative.GreaterThan:
                    sb.Append("Greater Than ");
                    break;
                case Comparative.GreaterThanOrEquals:
                    sb.Append("Greater Than or Equal To ");
                    break;
                case Comparative.LessThan:
                    sb.Append("Less Than ");
                    break;
                case Comparative.LessThanOrEquals:
                    sb.Append("Less Than or Equal To ");
                    break;
            }
            sb.Append("\"");
            sb.Append(Value);
            sb.Append("\"");
            return sb.ToString();
        }
    }
}
