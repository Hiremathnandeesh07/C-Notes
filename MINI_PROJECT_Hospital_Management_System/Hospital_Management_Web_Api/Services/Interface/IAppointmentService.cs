using Hospital_Management_Web_Api.Models.Appointment;
using Hospital_Management_Web_Api.Models.Appointment.DTOs;

namespace Hospital_Management_Web_Api.Services.Interface
{
    public interface IAppointmentService
    {
        // Books an appointment
        Task BookAppointmentAsync(BookAppointmentDto dto);

        // Cancels an appointment
        Task CancelAppointmentAsync(int appointmentId);

        // Retrieves upcoming appointments
        Task<List<Appointment>> GetUpcomingAppointmentsAsync();

        // Retrieves appointments for a doctor
        Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorCode);
    }
}
