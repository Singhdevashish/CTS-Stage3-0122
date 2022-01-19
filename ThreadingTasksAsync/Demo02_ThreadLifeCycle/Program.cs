using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo02_ThreadLifeCycle
{
    class Program
    {
        public static void Main()
        {
            ThreadStart task1 = new ThreadStart(ProcessTask1);
            Thread t1 = new Thread(task1);
            t1.Start();
            if (t1.IsAlive == true)
            {
                Console.WriteLine("Thread t1 is alive");
            }
            Console.WriteLine("Main thread in action");
            t1.Join();
            if (t1.IsAlive == false)
            {
                Console.WriteLine("Thread t1 is not alive");
            }
            Console.WriteLine("Main thread in action");
        }
        static void ProcessTask1()
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                {
                    Thread.CurrentThread.Abort();
                }
                Console.WriteLine("Thread t1 in action");
                Thread.Sleep(500);
            }
        }
    }
}


    
