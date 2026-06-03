using Hospital_Management_Web_Api.Models.Report.DTOs;
using Hospital_Management_Web_Api.Repositories.Interface;

namespace Hospital_Management_Web_Api.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        // Constructor for ReportService
        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        // Retrieves appointment report data
        public async Task<List<AppointmentReportDto>> GetAppointmentReportAsync()
        {
            return await _repository.GetAppointmentReportAsync();
        }

        // Retrieves revenue grouped by specialization
        public async Task<List<RevenueBySpecializationDto>> GetRevenueBySpecializationAsync()
        {
            return await _repository.GetRevenueBySpecializationAsync();
        }

        // Retrieves doctors with more than two appointments
        public async Task<List<DoctorAppointmentStatsDto>> GetDoctorsWithMoreThan2AppointmentsAsync()
        {
            return await _repository.GetDoctorsWithMoreThan2AppointmentsAsync();
        }
    }
}