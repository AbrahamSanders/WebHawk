using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UBoat.Utils.Threading
{
    public class ThreadSynchronizer
    {
        private SynchronizationContext m_SyncContext;
        private int m_ThreadId;

        public ThreadSynchronizer()
        {
            m_SyncContext = SynchronizationContext.Current;
            m_ThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        public void RunOnSynchronizedThread(Action action)
        {
            RunOnSynchronizedThread(action, false);
        }

        public void RunOnSynchronizedThread(Action action, bool wait)
        {
            if (Thread.CurrentThread.ManagedThreadId != m_ThreadId)
            {
                if (wait)
                {
                    m_SyncContext.Send((obj) => RunOnSynchronizedThread(action), null);
                }
                else
                {
                    m_SyncContext.Post((obj) => RunOnSynchronizedThread(action), null);
                }
            }
            else
            {
                action();
            }
        }
    }
}
