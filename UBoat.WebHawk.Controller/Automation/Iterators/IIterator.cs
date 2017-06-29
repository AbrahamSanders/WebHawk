using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Automation.Iterators
{
    internal interface IIterator : IDisposable
    {
        void Iterate();
        bool CanIterate { get; }
    }
}
