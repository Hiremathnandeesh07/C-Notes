using Hospital_Management_Web_Api.Models.Doctor;
using Hospital_Management_Web_Api.Models.Doctor.DTOs;
using Hospital_Management_Web_Api.Models.Patient;
using Hospital_Management_Web_Api.Repositories;
using Hospital_Management_Web_Api.Repositories.Interface;
using Hospital_Management_Web_Api.Services.Interface;

namespace Hospital_Management_Web_Api.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        // Constructor for DoctorService
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

     

        // Adds a new doctor after validation
        public async Task AddDoctorAsync(CreateDoctorDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new Exception("Doctor name is required.");

            if (string.IsNullOrWhiteSpace(dto.Specialization))
                throw new Exception("Specialization is required.");

            if (dto.ConsultationFee <= 0)
                throw new Exception("Consultation fee must be greater than zero.");

            await _doctorRepository.AddDoctorAsync(dto);
        }

        // Retrieves list of doctors
        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            return await _doctorRepository.GetDoctorsAsync();
        }

        // Returns underlying doctor repository (internal use)
        public IDoctorRepository Get_doctorRepository1()
        {
            return _doctorRepository;
        }

        // Retrieves doctors by specialization after validation
        public async Task<List<Doctor>> GetDoctorsBySpecializationAsync(
            string specialization)
        {
            if (string.IsNullOrWhiteSpace(specialization))
                throw new Exception("Specialization is required.");

            return await _doctorRepository.GetDoctorsBySpecializationAsync(specialization);
        }

      
    }
}
