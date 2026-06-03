using Hospital_Management_Web_Api.Models.Doctor;
using Hospital_Management_Web_Api.Models.Doctor.DTOs;

namespace Hospital_Management_Web_Api.Services.Interface
{
    public interface IDoctorService
    {
        // Adds a new doctor
        Task AddDoctorAsync(CreateDoctorDto dto);

        // Retrieves all doctors
        Task<List<Doctor>> GetDoctorsAsync();

        // Retrieves doctors by specialization
        Task<List<Doctor>> GetDoctorsBySpecializationAsync(string specialization);
    }
}
