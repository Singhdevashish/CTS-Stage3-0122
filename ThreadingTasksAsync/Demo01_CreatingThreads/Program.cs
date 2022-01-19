using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo01_CreatingThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main method under execution on thread: {0}", Thread.CurrentThread.ManagedThreadId);

            ThreadStart task1 = new ThreadStart(ProcessTask1);
            ThreadStart task2 = new ThreadStart(ProcessTask2);
            Thread t1 = new Thread(task1);
            Thread t2 = new Thread(task2);
          
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("Exiting main method");
        }

        static void ProcessTask1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("ProcessTask1 under execution on thread: {0}",  Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(500);
            }
        }
        static void ProcessTask2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("ProcessTask2 under execution on thread: {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            }
        }
    }
}
