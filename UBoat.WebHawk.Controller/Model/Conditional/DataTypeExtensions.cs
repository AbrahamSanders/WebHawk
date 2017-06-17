using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Model.Conditional
{
    public static class DataTypeExtensions
    {
        public static List<Comparative> GetSupportedComparatives(this DataType dataType)
        {
            switch (dataType)
            {
                case DataType.String:
                    return new List<Comparative>()
                    {
                        Comparative.Equals,
                        Comparative.Contains,
                        Comparative.BeginsWith,
                        Comparative.EndsWith,
                        Comparative.RegexMatch
                    };
                case DataType.DateTime:
                case DataType.Numeric:
                    return new List<Comparative>()
                    {
                        Comparative.Equals,
                        Comparative.GreaterThan,
                        Comparative.GreaterThanOrEquals,
                        Comparative.LessThan,
                        Comparative.LessThanOrEquals
                    };
                case DataType.Boolean:
                    return new List<Comparative>()
                    {
                         Comparative.Equals
                    };
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
