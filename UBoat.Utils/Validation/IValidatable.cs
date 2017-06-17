using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.Validation
{
    public interface IValidatable
    {
        ValidationResult PerformValidation();
    }
}
