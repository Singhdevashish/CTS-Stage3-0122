using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo03_ThreadPool
{
    class Program
    {
        public static void Main()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessTask), null);
            Console.WriteLine("Main thread in action");
            Thread.Sleep(2000);
            Console.WriteLine("Main thread in action");
        }
        static void ProcessTask(object param)
        {
            //Thread.Sleep(5000);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Thread t1 in action");
            }
        }
    }

}
