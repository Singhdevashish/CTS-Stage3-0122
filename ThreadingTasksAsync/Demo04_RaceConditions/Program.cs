using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo04_RaceConditions
{
    class Program
    {
        static int count = 0;
     
        public static void Main()
        {
            ThreadStart td = new ThreadStart(ProcessTask);
            Thread t1 = new Thread(td);
            t1.Start();
            for (int i = 0; i < 5; i++)
            {
                int temp = count;
                Thread.Sleep(5);
                temp = temp + 1;
                count = temp;
            }
            t1.Join();
            Console.WriteLine(count);
        }
        static void ProcessTask()
        {
            for (int i = 0; i < 5; i++)
            {
                int temp = count;
                Thread.Sleep(5);
                temp = temp + 1;
                count = temp;
            }
        }
    }


}
