using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo06_DeadLocks
{
    class Program
    {
        static Mutex firstLock = new Mutex();
        static Mutex secondLock = new Mutex();
        public static void Main()
        {
            ThreadStart td = new ThreadStart(ProcessTask);
            Thread t = new Thread(td);
            t.Start();
            Thread.Sleep(500);

            secondLock.WaitOne();
            Console.WriteLine("Main: Second lock applied");

            firstLock.WaitOne();
            Console.WriteLine("Main: First lock applied");
            Console.WriteLine("Main: First lock released");
            firstLock.ReleaseMutex();

            secondLock.ReleaseMutex();

            Console.WriteLine("Main: Second lock released");
        }
        static void ProcessTask()
        {
            firstLock.WaitOne();
            Console.WriteLine("t: First lock applied");
            Thread.Sleep(1000);
            
            secondLock.WaitOne();
            Console.WriteLine("t: Second lock applied");
            secondLock.ReleaseMutex();

            Console.WriteLine("t: Second lock released");
            firstLock.ReleaseMutex();
            Console.WriteLine("t: First lock released");
        }
    }


}
