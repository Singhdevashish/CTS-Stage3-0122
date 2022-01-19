using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo08_TasksAndParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main() started on Thread Id : {0}", Thread.CurrentThread.ManagedThreadId);
            var t1 = new Task(BookFlight, "Syed");
            var t2 = new Task(BookHotel, "Syed");

            t1.Start();
            t2.Start();
            Task.WaitAll(t1, t2);
            Console.WriteLine("Main() completed");
        }
        static void BookFlight(object name)
        {
            Console.WriteLine("Booking flight for {0}", name);
            Console.WriteLine("Flight booking started on Thread Id : {0}", Thread.CurrentThread.ManagedThreadId);
            System.Threading.Thread.Sleep(1000);
            var ticketNo = new Random().Next();
            Console.WriteLine("Flight booking completed. Ticket id : {0}", ticketNo);
        }

        static void BookHotel(object name)
        {
            Console.WriteLine("Booking hotel for {0}", name);

            Console.WriteLine("Hotel booking started on Thread Id : {0}", Thread.CurrentThread.ManagedThreadId);
            System.Threading.Thread.Sleep(1500);
            var bookingId = new Random().Next();
            Console.WriteLine("Hotel booking completed. Ticket id : {0}", bookingId);
        }
    }
}