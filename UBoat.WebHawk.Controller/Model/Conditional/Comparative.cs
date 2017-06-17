using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Conditional
{
    [Serializable]
    public enum Comparative
    {
        Equals,
        Contains,
        BeginsWith,
        EndsWith,
        GreaterThan,
        GreaterThanOrEquals,
        LessThan,
        LessThanOrEquals,
        RegexMatch
    }
}
