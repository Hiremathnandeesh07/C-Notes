using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FlightBooking_Console_App.Models;
using static FlightBooking_Console_App.Models.Flights;

namespace FlightBooking_Console_App.Services
{
    internal class FlightService
    {
        private readonly HttpClient _client;

        public FlightService()
        {
            _client = new HttpClient();

            _client.BaseAddress =
                new Uri("http://localhost:5182/api/");
        }


        // GET ALL FLIGHTS

        public async Task<List<Flight>> GetAllFlights()
        {
            HttpResponseMessage response =
                await _client.GetAsync("flights");

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Flight>>(json);
        }



        // GET FLIGHT BY ID

        public async Task<Flight> GetFlightById(int id)
        {
            HttpResponseMessage response =
                await _client.GetAsync($"flights/{id}");

            if (response.IsSuccessStatusCode)
            {
                string json =
                    await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Flight>(json);
            }

            return null;
        }

        // ADD FLIGHT

        public async Task<bool> AddFlight(Flight flight)
        {
            string json =
                JsonConvert.SerializeObject(flight);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                await _client.PostAsync("flights", content);

            return response.IsSuccessStatusCode;
        }

        // UPDATE FLIGHT

        public async Task<bool> UpdateFlight(int id, Flight flight)
        {
            string json =
                JsonConvert.SerializeObject(flight);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpRequestMessage request =
                new HttpRequestMessage(
                    new HttpMethod("PATCH"),
                    $"flights/{id}");

            request.Content = content;

            HttpResponseMessage response =
                await _client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        // DELETE FLIGHT

        public async Task<bool> DeleteFlight(int id)
        {
            HttpResponseMessage response =
                await _client.DeleteAsync($"flights/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}