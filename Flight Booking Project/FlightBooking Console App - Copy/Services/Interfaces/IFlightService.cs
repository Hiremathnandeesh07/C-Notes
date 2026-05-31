using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlightBooking_Console_App.Models;

namespace FlightBooking_Console_App.Services.Interfaces
{
    public interface IFlightService
    {
        Task<List<Flight>> GetAllFlights();

        Task<Flight> GetFlightById(int id);

        Task<bool> AddFlight(Flight flight);

        Task<bool> UpdateFlight(int id, Flight flight);

        Task<bool> DeleteFlight(int id);
    }
}
