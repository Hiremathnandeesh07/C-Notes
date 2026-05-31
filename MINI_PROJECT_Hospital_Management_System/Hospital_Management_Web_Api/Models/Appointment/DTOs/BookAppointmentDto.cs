namespace Hospital_Management_Web_Api.Models.Appointment.DTOs
{
    public class BookAppointmentDto
    {
        public int PatientCode { get; set; }

        public int DoctorCode { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string? PatientName { get; internal set; }
    }
}