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

        public FlightTicket(DateTime journeyDate, string flightNo)
        {
            this.JourneyDate = journeyDate;
            this.FlightNo = flightNo;
        }
        public void Book(string passengerName)
        {
            this.PassengerName = passengerName;
            this.BookingDate = DateTime.Today;
            this.Status = "Booked";
        }
        public void Cancel()
        {
            this.Status = "Available";
            this.PassengerName = string.Empty;
        }
        public void Print()
        {
            Console.WriteLine("Passenger : {0}", PassengerName);
            Console.WriteLine("Journey : {0}", JourneyDate);
            Console.WriteLine("Flight : {0}", FlightNo);
            Console.WriteLine("Booking : {0}", BookingDate);
            Console.WriteLine("Status : {0}", Status);

        }
    }
}
