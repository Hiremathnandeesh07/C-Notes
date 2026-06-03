using Hospital_Management_Web_Api.Models.Patient;
using Hospital_Management_Web_Api.Models.Patient.DTOs;

namespace Hospital_Management_Web_Api.Services.Interface
{
    public interface IPatientService
    {
        // Adds a new patient
        Task AddPatientAsync(CreatePatientDto dto);

        // Updates an existing patient
        Task UpdatePatientAsync(int patientCode, UpdatePatientDto dto);

        // Deactivates a patient
        Task DeactivatePatientAsync(int patientCode);

        // Retrieves a patient by id
        Task<Patient?> GetPatientByIdAsync(int patientCode);

        // Retrieves all patients
        Task<List<Patient>> GetAllPatientsAsync();
    }
}
