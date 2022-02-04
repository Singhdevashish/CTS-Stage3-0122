using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace SingletonDemo
{
    public class Logger
    {
        private static int instanceCount = 0;
        //private static Logger _logger = null;
        //private static Mutex mutex = new Mutex();
        //private static object _lock=new object();
        private static Lazy<Logger> logger = new Lazy<Logger>(new Logger());
        private Logger()
        {
            instanceCount += 1;
            Console.WriteLine("Total Instances : {0}", instanceCount);
        }
        public static Logger Instance
        {
            get
            {
                //mutex.WaitOne();
                //if (_logger == null)
                //    _logger = new Logger();
                //mutex.ReleaseMutex();
                //lock (_lock)
                //{
                //    if (_logger == null)
                //        _logger = new Logger();
                //}
                // return _logger;
                return logger.Value;
            }
        }
        public void Log(string message)
        {
            Console.WriteLine("Logger {0} ", message);
        }
    }
}
