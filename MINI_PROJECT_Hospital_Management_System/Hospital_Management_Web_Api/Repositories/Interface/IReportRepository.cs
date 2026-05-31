using Hospital_Management_Web_Api.Models.Report.DTOs;

public interface IReportRepository
{
    Task<List<AppointmentReportDto>> GetAppointmentReportAsync();

    Task<List<RevenueBySpecializationDto>> GetRevenueBySpecializationAsync();

    Task<List<DoctorAppointmentStatsDto>> GetDoctorsWithMoreThan2AppointmentsAsync();
}