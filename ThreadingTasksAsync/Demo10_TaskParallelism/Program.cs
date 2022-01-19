using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo10_TaskParallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main() running on Thread : {0}", Thread.CurrentThread.ManagedThreadId);
            var numbers = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            var sw = new Stopwatch();
            sw.Start();
            Parallel.ForEach(numbers, n => Process(n));
            //foreach (var n in numbers) Process(n);
            sw.Stop();
            Console.WriteLine("Processing completed in : {0}ms", sw.ElapsedMilliseconds);
            Console.WriteLine("Main terminated");

        }

        static void Process(int num)
        {
            Thread.Sleep(500);
            Console.WriteLine("Processing the number : {0} on Thread {1}", num, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
