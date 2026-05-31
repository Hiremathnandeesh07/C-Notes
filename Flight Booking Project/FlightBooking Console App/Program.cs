using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightBooking_Console_App.Models;
using FlightBooking_Console_App.Services;
using static FlightBooking_Console_App.Models.Flights;

namespace FlightBooking_Console_App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            FlightService service =
                new FlightService();

            // GET ALL FLIGHTS

            Console.WriteLine("GET ALL FLIGHTS\n");

            List<Flight> flights =
                await service.GetAllFlights();

            foreach (var f in flights)
            {
                Console.WriteLine(
                    $"Id: {f.FlightId}, " +
                    $"Flight No: {f.FlightNumber}, " +
                    $"From: {f.SourceCity}, " +
                    $"To: {f.DestinationCity}, " +
                    $"Departure: {f.DepartureTime}, " +
                    $"Price: {f.Price}, " +
                    $"Seats: {f.AvailableSeats}");
            }

            // GET FLIGHT BY ID

            Console.WriteLine("\nGET FLIGHT BY ID\n");

            Flight flight =
                await service.GetFlightById(1);

            if (flight != null)
            {
                Console.WriteLine(
                    $"Id: {flight.FlightId}, " +
                    $"Flight No: {flight.FlightNumber}, " +
                    $"From: {flight.SourceCity}, " +
                    $"To: {flight.DestinationCity}, " +
                    $"Departure: {flight.DepartureTime}, " +
                    $"Price: {flight.Price}, " +
                    $"Seats: {flight.AvailableSeats}");
            }
            else
            {
                Console.WriteLine("Flight not found");
            }

            // ADD FLIGHT

            Console.WriteLine("\nADD FLIGHT\n");

            Flight newFlight =
                new Flight()
                {
                    FlightNumber = "AI202",
                    SourceCity = "Bangalore",
                    DestinationCity = "Delhi",
                    DepartureTime = DateTime.Now.AddHours(5),
                    Price = 6500,
                    AvailableSeats = 120
                };

            bool isAdded =
                await service.AddFlight(newFlight);

            Console.WriteLine(
                isAdded
                ? "Flight added successfully"
                : "Failed to add flight");

            // UPDATE FLIGHT

            Console.WriteLine("\nUPDATE FLIGHT\n");

            Flight updatedFlight =
                new Flight()
                {
                    FlightId = 1,
                    FlightNumber = "AI999",
                    SourceCity = "Mumbai",
                    DestinationCity = "Chennai",
                    DepartureTime = DateTime.Now.AddHours(3),
                    Price = 9000,
                    AvailableSeats = 90
                };

            bool isUpdated =
                await service.UpdateFlight(1, updatedFlight);

            Console.WriteLine(
                isUpdated
                ? "Flight updated successfully"
                : "Failed to update flight");

            // DELETE FLIGHT

            Console.WriteLine("\nDELETE FLIGHT\n");

            bool isDeleted =
                await service.DeleteFlight(2);

            Console.WriteLine(
                isDeleted
                ? "Flight deleted successfully"
                : "Failed to delete flight");




            

           
        }
    }
}