using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UBoat.WebHawk.Controller.Model.Conditional
{
    [Serializable]
    public class LogicalNode : ConditionNode
    {
        public Conditional ConditionalOperator { get; set; }
        public List<ConditionNode> Nodes { get; set; }
    }
}
