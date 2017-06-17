using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UBoat.WebHawk.Controller.Model.Data
{
    [Serializable]
    public enum DataType
    {
        List,
        Object,
        String,
        DateTime,
        Numeric,
        Boolean
    }
}
