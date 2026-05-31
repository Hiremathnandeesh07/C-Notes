using FlightBooking_Console_App.Services;
using FlightBooking_Console_App.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace FlightBooking_Console_App.Configuration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHttpClient<IFlightService, FlightService>(client =>
            {
                client.BaseAddress =
                    new Uri(configuration["ApiSettings:BaseUrl"]);
            });

            return services;
        }
    }
}