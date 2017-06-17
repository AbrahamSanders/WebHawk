using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.Controller.Integration.SequenceTranslators
{
    public interface ISequenceTranslator
    {
        object Translate(List<Step> sequence);
    }
}
