using FlightTicketLib;
using System;

namespace FlightTicketLibClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticket = new FlightTicket(DateTime.Now.AddDays(10), "6E220");
            ticket.Cancel();
            ticket.Book("Jojo");
            ticket.Print();
            ticket.Cancel();
            ticket.Book("Syed");
            ticket.Print();
            //ticket.Cancel();
            //ticket.Print();
            
        }
    }
}
