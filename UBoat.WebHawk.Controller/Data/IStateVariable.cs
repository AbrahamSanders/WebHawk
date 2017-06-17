using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Data
{
    public interface IStateVariable
    {
        string Name { get; set; }
        DataType DataType { get; set; }
        XMLFieldOutputMode XMLFieldOutputMode { get; }
        PersistenceMode PersistenceMode { get; }
        string ValueAsString();
        IStateVariable Copy(bool persistedChildrenOnly = false);
    }
}
