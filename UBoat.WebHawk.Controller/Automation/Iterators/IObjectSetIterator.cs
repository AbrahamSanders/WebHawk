using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;

namespace UBoat.WebHawk.Controller.Automation.Iterators
{
    internal interface IObjectSetIterator : IIterator
    {
        ObjectStateVariable CurrentObjectStateVariable { get; }
        ObjectSetIteration ObjectSetIteration { get; }
    }
}
