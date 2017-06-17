using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UBoat.Utils.Threading
{
    public static class ThreadingUtils
    {
        public static void InvokeControlAction<t>(t cont, Action<t> action) where t : Control
        {
            try
            {
                if (cont.InvokeRequired)
                {
                    cont.Invoke(new Action<t, Action<t>>(InvokeControlAction),
                              new object[] { cont, action });
                }
                else
                { action(cont); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExecuteAsync(Action action)
        {
            ExecuteAsync(action, "ExecuteAsync_" + Guid.NewGuid().ToString(), ApartmentState.MTA);
        }

        public static void ExecuteAsync(Action action, string threadname, ApartmentState AptState)
        {
            try
            {
                Thread thread = new Thread(() =>
                {
                    action();
                });
                thread.Name = threadname;
                thread.SetApartmentState(AptState);
                thread.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
