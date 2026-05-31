using System;

namespace FlightBooking_Console_App.Models
{
    internal class Flights
    {
        public class Flight
        {
            public int FlightId { get; set; }

            public string FlightNumber { get; set; }

            public string SourceCity { get; set; }

            public string DestinationCity { get; set; }

            public DateTime DepartureTime { get; set; }

            public decimal Price { get; set; }

            public int AvailableSeats { get; set; }
        }
    }
}