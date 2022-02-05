using System;

namespace FlightTicketLib
{
    public class FlightTicket
    {
        public string FlightNo { get; set; }
        public string PassengerName { get; set; }
        public DateTime JourneyDate { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
        private TicketStates currentState;
        public FlightTicket(DateTime journeyDate, string flightNo)
        {
            this.JourneyDate = journeyDate;
            this.FlightNo = flightNo;
            ChangeState(new TicketAvailable());
        }
        public void Book(string passengerName)
        {
            currentState.Book(passengerName);          
        }
        public void Cancel()
        {
            currentState.Cancel();
          
        }
        public void Print()
        {
            Console.WriteLine("Passenger : {0}", PassengerName);
            Console.WriteLine("Journey : {0}", JourneyDate);
            Console.WriteLine("Flight : {0}", FlightNo);
            Console.WriteLine("Booking : {0}", BookingDate);
            Console.WriteLine("Status : {0}", Status);

        }
        public void ChangeState(TicketStates state)
        {
            currentState = state;
            currentState.SetContext(this);
        }
    }

    public interface TicketStates
    {
        void Book(string passengerName);
        void Cancel();
        void SetContext(FlightTicket ticket);
    }
    public class TicketAvailable : TicketStates
    {
        private FlightTicket ticket;
        public void Book(string passengerName)
        {
            ticket.PassengerName = passengerName;
            ticket.BookingDate = DateTime.Today;
            ticket.ChangeState(new TicketBooked());
        }

        public void Cancel()
        {
            Console.WriteLine("Unreserved ticket cannot be cancelled");
        }

        public void SetContext(FlightTicket ticket)
        {
            this.ticket = ticket;
        }
    }

    public class TicketBooked : TicketStates
    {
        private FlightTicket ticket;
        public void Book(string passengerName)
        {
            Console.WriteLine("Ticket is already reserved for {0}", ticket.PassengerName);
        }

        public void Cancel()
        {
            ticket.PassengerName = string.Empty;
            ticket.BookingDate = DateTime.MinValue;
            ticket.ChangeState(new TicketAvailable());
        }

        public void SetContext(FlightTicket ticket)
        {
            this.ticket = ticket;
        }
    }
}
