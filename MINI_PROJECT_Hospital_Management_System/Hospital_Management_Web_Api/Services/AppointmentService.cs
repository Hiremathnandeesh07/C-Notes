using Hospital_Management_Web_Api.Models.Appointment;
using Hospital_Management_Web_Api.Models.Appointment.DTOs;
using Hospital_Management_Web_Api.Repositories.Interface;
using Hospital_Management_Web_Api.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_Web_Api.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task BookAppointmentAsync(BookAppointmentDto dto)
        {
            // Validate required fields (DTO model validation should already run,
            // but validate defensively in service layer as well).
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (!dto.DoctorCode.HasValue || dto.DoctorCode.Value <= 0)
                throw new ValidationException("Invalid or missing doctor code.");

            if (!dto.PatientCode.HasValue || dto.PatientCode.Value <= 0)
                throw new ValidationException("Invalid or missing patient code.");

            if (!dto.AppointmentDate.HasValue)
                throw new ValidationException("Missing appointment date.");

            await _repo.BookAppointmentAsync(dto);
        }

        public async Task CancelAppointmentAsync(int appointmentId)
        {
            if (appointmentId <= 0)
                throw new Exception("Invalid appointment id");

            await _repo.CancelAppointmentAsync(appointmentId);
        }

        public async Task<List<Appointment>> GetUpcomingAppointmentsAsync()
        {
            return await _repo.GetUpcomingAppointmentsAsync();
        }

        public async Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorCode)
        {
            if (doctorCode <= 0)
                throw new Exception("Invalid doctor code");

            return await _repo.GetDoctorAppointmentsAsync(doctorCode);
        }
    }
}
