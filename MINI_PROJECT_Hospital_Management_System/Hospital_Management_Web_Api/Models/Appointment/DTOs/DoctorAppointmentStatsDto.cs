namespace Hospital_Management_Web_Api.Models.Report.DTOs
{
    public class DoctorAppointmentStatsDto
    {
        public int DoctorCode { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public int AppointmentCount { get; set; }
    }
}