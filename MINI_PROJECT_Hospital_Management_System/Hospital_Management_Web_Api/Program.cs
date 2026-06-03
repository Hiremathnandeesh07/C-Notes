using Hospital_Management_Web_Api;
using Hospital_Management_Web_Api.Helpers;
using Hospital_Management_Web_Api.Middleware;
using Hospital_Management_Web_Api.Middlewares;
using Hospital_Management_Web_Api.Repositories;
using Hospital_Management_Web_Api.Repositories.Interface;
using Hospital_Management_Web_Api.Services;
using Hospital_Management_Web_Api.Services.Interface;

public static class Program
{
    // Application entry point
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<EmailService>();

        // adding DATABASE DI
        builder.Services.AddScoped<DatabaseHelper>();

        // adding Patient related service
        builder.Services.AddScoped<IPatientRepository, PatientRepository>();
        builder.Services.AddScoped<IPatientService, PatientService>();


        // addin doctor related service
        builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();

        builder.Services.AddScoped<IDoctorService, DoctorService>();


        // adding appointment related service
        builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        builder.Services.AddScoped<IAppointmentService, AppointmentService>();


        // adding report related service
        builder.Services.AddScoped<IReportRepository, ReportRepository>();
        builder.Services.AddScoped<IReportService, ReportService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Exception middleware should be registered early so it can catch
        // exceptions thrown by downstream middleware and controllers.
        app.UseMiddleware<ExceptionMiddleware>();

        // Request logging should run after exception handling but before
        // routing/authorization so it records every incoming request.
        app.UseMiddleware<RequestLoggingMiddleware>();

        // Ensure routing is enabled before authorization and endpoints are mapped.
        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
