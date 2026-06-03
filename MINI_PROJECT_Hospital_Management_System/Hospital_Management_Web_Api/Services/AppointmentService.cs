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
        private readonly EmailService _emailService;
        private readonly IPatientRepository _patientRepo;

        // Constructor for AppointmentService
        public AppointmentService(
            IAppointmentRepository repo,
            EmailService emailService,
            IPatientRepository patientRepo)
        {
            _repo = repo;
            _emailService = emailService;
            _patientRepo = patientRepo;
        }

        // Books an appointment after validation
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


            var patient =
        await _repo.GetPatientEmailDetailsAsync(
            dto.PatientCode.Value);

            if (patient != null &&
                !string.IsNullOrWhiteSpace(patient.Email))
            {
                await _emailService.SendAppointmentEmailAsync(
                    patient.Email,
                    patient.FullName,
                    dto.AppointmentDate.Value);
            }


        }

        // Cancels an appointment
        public async Task CancelAppointmentAsync(int appointmentId)
        {
            if (appointmentId <= 0)
                throw new Exception("Invalid appointment id");

            await _repo.CancelAppointmentAsync(appointmentId);
        }

        // Retrieves upcoming appointments
        public async Task<List<Appointment>> GetUpcomingAppointmentsAsync()
        {
            return await _repo.GetUpcomingAppointmentsAsync();
        }

        // Retrieves appointments for a given doctor
        public async Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorCode)
        {
            if (doctorCode <= 0)
                throw new Exception("Invalid doctor code");

            return await _repo.GetDoctorAppointmentsAsync(doctorCode);
        }
    }
}
