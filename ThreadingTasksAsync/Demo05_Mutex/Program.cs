using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo05_Mutex
{
    class Program
    {
        static int count = 0;
        static Mutex mutex = new Mutex();
        public static void Main()
        {
            ThreadStart td = new ThreadStart(ProcessTask);
            Thread t1 = new Thread(td);
            t1.Start();
            
            for (int i = 0; i < 5; i++)
            {
                mutex.WaitOne();
                int temp = count;
                Thread.Sleep(5);
                temp = temp + 1;
                count = temp;
                mutex.ReleaseMutex();
            }
            t1.Join();
            Console.WriteLine(count);
        }
        static void ProcessTask()
        {         
            for (int i = 0; i < 5; i++)
            {
                mutex.WaitOne();
                int temp = count;
                Thread.Sleep(5);
                temp = temp + 1;
                count = temp;
                mutex.ReleaseMutex();
            }
        }
    }
   
}
