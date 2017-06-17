using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Management;

namespace UBoat.Utils
{
    public static class ProcessMonitor
    {
        private static ManagementEventWatcher m_StartWatcher;
        private static ManagementEventWatcher m_StopWatcher;
        private static bool m_IsRunning;

        public static int Subscribers
        {
            get
            {
                int pstart = ProcessStarted == null ? 0 : ProcessStarted.GetInvocationList().Length;
                int pstop = ProcessStopped == null ? 0 : ProcessStopped.GetInvocationList().Length;
                return pstart + pstop;
            }
        }

        public static bool IsRunning
        {
            get
            {
                return m_IsRunning;
            }
        }

        static ProcessMonitor()
        {
            m_StartWatcher = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            m_StartWatcher.EventArrived += new EventArrivedEventHandler(m_StartWatcher_EventArrived);
            m_StopWatcher = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            m_StopWatcher.EventArrived += new EventArrivedEventHandler(m_StopWatcher_EventArrived);
        }

        static void m_StartWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            zOnProcessStarted(new ProcessStartEventArgs()
            {
                Process = Process.GetProcessesByName(e.NewEvent.Properties["ProcessName"].Value.ToString()).FirstOrDefault()
            });
        }

        static void m_StopWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            zOnProcessStopped(new ProcessStopEventArgs()
            {
                ProcessName = e.NewEvent.Properties["ProcessName"].Value.ToString()
            });
        }

        public static void Start()
        {
            m_IsRunning = true;
            m_StartWatcher.Start();
            m_StopWatcher.Start();
        }
        public static void Stop()
        {
            m_StartWatcher.Stop();
            m_StopWatcher.Stop();
            m_IsRunning = false;
        }

        public static List<Process> GetProcesses()
        {
            return Process.GetProcesses().ToList();
        }

        public static event EventHandler<ProcessStartEventArgs> ProcessStarted;
        private static void zOnProcessStarted(ProcessStartEventArgs e)
        {
            EventHandler<ProcessStartEventArgs> evnt = ProcessStarted;
            if (evnt != null)
            {
                foreach (Delegate dlg in evnt.GetInvocationList())
                {
                    try
                    {
                        ((EventHandler<ProcessStartEventArgs>)dlg)(null, e);
                    }
                    catch (Exception)
                    {
                        //Oh well. Hit the bricks.
                    }
                }
            }
        }
        public static event EventHandler<ProcessStopEventArgs> ProcessStopped;
        private static void zOnProcessStopped(ProcessStopEventArgs e)
        {
            EventHandler<ProcessStopEventArgs> evnt = ProcessStopped;
            if (evnt != null)
            {
                foreach (Delegate dlg in evnt.GetInvocationList())
                {
                    try
                    {
                        ((EventHandler<ProcessStopEventArgs>)dlg)(null, e);
                    }
                    catch (Exception)
                    {
                        //Oh well. Hit the bricks.
                    }
                }
            }
        }
    }

    public class ProcessStartEventArgs : EventArgs
    {
        public Process Process { get; set; }
    }
    public class ProcessStopEventArgs : EventArgs
    {
        public string ProcessName { get; set; }
    }
}
