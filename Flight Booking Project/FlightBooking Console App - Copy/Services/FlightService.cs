using FlightBooking_Console_App.Models;
using FlightBooking_Console_App.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking_Console_App.Services
{
    public class FlightService : IFlightService
    {
        private readonly HttpClient _client;

        public FlightService(HttpClient client)
        {
            _client = client;
        }

        // GET ALL FLIGHTS

        public async Task<List<Flight>> GetAllFlights()
        {
            HttpResponseMessage response =
                await _client.GetAsync("flights");

            if (!response.IsSuccessStatusCode)
            {
                return new List<Flight>();
            }

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Flight>>(json);
        }

        // GET FLIGHT BY ID

        public async Task<Flight> GetFlightById(int id)
        {
            HttpResponseMessage response =
                await _client.GetAsync($"flights/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Flight>(json);
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

            

            // Create PATCH request manually
            HttpRequestMessage patchRequest =
                new HttpRequestMessage(
                    new HttpMethod("PATCH"),
                    $"products/{id}");



            patchRequest.Content = content;

            HttpResponseMessage response =
                await _client.SendAsync(patchRequest);

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