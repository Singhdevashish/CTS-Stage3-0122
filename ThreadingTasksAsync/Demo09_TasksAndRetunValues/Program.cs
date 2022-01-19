using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo09_TasksAndRetunValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main() started on Thread Id : {0}", Thread.CurrentThread.ManagedThreadId);
            var t1 = new Task<int>(BookFlight, "Syed");
            var t2 = new Task<int>(BookHotel, "Syed");

            t1.Start();
            t2.Start();
            Task.WaitAll(t1, t2);
            Console.WriteLine("Flight Id : {0}", t1.Result);
            Console.WriteLine("Hotel Id : {0}", t2.Result);
            Console.WriteLine("Main() completed");
        }
        static int BookFlight(object name)
        {
            Console.WriteLine("Booking flight for {0}", name);
            Console.WriteLine("Flight booking started on Thread Id : {0}", Thread.CurrentThread.ManagedThreadId);
            System.Threading.Thread.Sleep(1000);
            var ticketNo = new Random().Next();
            return ticketNo;
        }

        static int BookHotel(object name)
        {
            Console.WriteLine("Booking hotel for {0}", name);

            Console.WriteLine("Hotel booking started on Thread Id : {0}", Thread.CurrentThread.ManagedThreadId);
            System.Threading.Thread.Sleep(1500);
            var bookingId = new Random().Next();
            return bookingId;
        }
    }
}
