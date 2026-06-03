using Hospital_Management_Web_Api.Models.Report.DTOs;
using Hospital_Management_Web_Api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        // Constructor for ReportController
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("appointments")]
        // Retrieves appointment report
        public async Task<IActionResult> GetAppointmentReport()
        {
            List<AppointmentReportDto> reports =
                await _reportService.GetAppointmentReportAsync();

            return Ok(reports);
        }

        [HttpGet("revenue")]
        // Retrieves revenue grouped by specialization
        public async Task<IActionResult> GetRevenueBySpecialization()
        {
            List<RevenueBySpecializationDto> reports =
                await _reportService.GetRevenueBySpecializationAsync();

            return Ok(reports);
        }

        [HttpGet("busy-doctors")]
        // Retrieves doctors with more than two appointments
        public async Task<IActionResult> GetDoctorsWithMoreThan2Appointments()
        {
            List<DoctorAppointmentStatsDto> reports =
                await _reportService.GetDoctorsWithMoreThan2AppointmentsAsync();

            return Ok(reports);
        }
    }
}