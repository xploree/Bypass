using System;
using System.Diagnostics;

namespace Bypass.Utils
{
    public sealed class ProcessViewer
    {
        private static readonly ProcessViewer instance = new ProcessViewer();

        static ProcessViewer()
        {
        }

        private ProcessViewer()
        {
        }

        public static ProcessViewer Instance
        {
            get
            {
                return instance;
            }
        }

        public Process[] GetAllProcesses()
        {
            Process[] processlist = Process.GetProcesses();

            return processlist;
        }

    }
}
