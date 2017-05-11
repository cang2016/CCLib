using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Logging
{
    public class LogWithTrace : ILoger
    {

        private static readonly object obj = new object();
        private string m_fileName;
        /// <summary>
        /// Single Instance
        /// </summary>
        private static LogWithTrace instance;
        public static LogWithTrace Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new LogWithTrace();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private LogWithTrace()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\";
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);
            this.m_fileName = basePath + string.Format("Log-{0}.txt", DateTime.Now.ToString("yyMMdd"));
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new TextWriterTraceListener(m_fileName));
        }

        public void Debug(object msg)
        {
            Trace.WriteLine(msg, "Debug");
            Trace.Flush();
            Trace.Close();
        }

        public void Warn(object msg)
        {
            Trace.WriteLine(msg, "Warn");
            Trace.Flush();
            Trace.Close();
        }

        public void Info(object msg)
        {
            Trace.WriteLine(msg, "Info");
            Trace.Flush();
            Trace.Close();
        }

        public void Error(object msg)
        {
            Trace.WriteLine(msg, "Error");
            Trace.Flush();
            Trace.Close();
        }
    }
}
