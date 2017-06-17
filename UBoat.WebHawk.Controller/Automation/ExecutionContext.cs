using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.Utils;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Conditional;
using UBoat.WebHawk.Controller.Data;

namespace UBoat.WebHawk.Controller.Automation
{
    internal class ExecutionContext
    {
        public WebBrowserHelper BrowserHelper { get; private set; }
        public ConditionalEngine ConditionalEngine { get; private set; }
        public ExecutionStack ExecutionStack { get; private set; }
        public DataContext DataContext { get; private set; }

        public ExecutionContext(WebBrowserHelper browserHelper)
        {
            this.BrowserHelper = browserHelper;
            this.ConditionalEngine = new ConditionalEngine();
            this.ExecutionStack = new ExecutionStack();
            this.DataContext = new DataContext();
        }
    }
}
