using FlightBooking_Console_App.Configuration;
using FlightBooking_Console_App.Models;
using FlightBooking_Console_App.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBooking_Console_App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // CREATE HOST

            var host =
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices((context, services) =>
                    {
                        services.AddApplicationServices(
                            context.Configuration);
                    })
                    .Build();

            // GET SERVICE FROM DI CONTAINER

            var flightService =
                host.Services.GetRequiredService<IFlightService>();


            // EXAMPLE USAGE

            List<Flight> flights =
                await flightService.GetAllFlights();

            foreach (var flight in flights)
            {
                Console.WriteLine(
                    $"{flight.FlightId} - {flight.FlightNumber}");
            }
        }
    }
}