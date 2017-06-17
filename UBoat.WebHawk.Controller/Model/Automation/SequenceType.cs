using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Automation
{
    [Serializable]
    public enum SequenceType
    {
        Watch = 1,
        Scrape = 2,
        FormFilling = 3,
        Navigation = 4,
        Search = 5,
        Testing = 6,
        Custom = 7
    }
}
