using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Logging
{
    public class SimpleLoger : ILoger
    {
        /// <summary>
        /// Single Instance
        /// </summary>
        private static SimpleLoger instance;
        public static SimpleLoger Instance
        {
            get
            {
                if (instance == null)
                    instance = new SimpleLoger();
                return instance;
            }

        }

        /// <summary>
        /// Constructor
        /// </summary>
        private SimpleLoger()
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new LogerTraceListener());
        }

        public void Debug(object msg)
        {
            Trace.WriteLine(msg, "Debug");
        }

        public void Warn(object msg)
        {
            Trace.WriteLine(msg, "Warn");
        }

        public void Info(object msg)
        {
            Trace.WriteLine(msg, "Info");
        }

        public void Error(object msg)
        {
            Trace.WriteLine(msg, "Error");
        }
    }
}
