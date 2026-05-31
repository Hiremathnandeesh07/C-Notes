namespace Hospital_Management_Web_Api.Models.Patient.DTOs
{
    public class CreatePatientDto
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}
