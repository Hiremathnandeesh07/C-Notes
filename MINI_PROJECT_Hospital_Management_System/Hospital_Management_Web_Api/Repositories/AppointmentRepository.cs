using Hospital_Management_Web_Api.Helpers;
using Hospital_Management_Web_Api.Models;
using Hospital_Management_Web_Api.Models.Appointment;
using Hospital_Management_Web_Api.Models.Appointment.DTOs;
using Hospital_Management_Web_Api.Repositories.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hospital_Management_Web_Api.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DatabaseHelper _dbHelper;

        // Constructor for AppointmentRepository
        public AppointmentRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Books an appointment in the database
        public async Task BookAppointmentAsync(BookAppointmentDto dto)
        {
            using SqlConnection con = _dbHelper.GetConnection();

            using SqlCommand cmd = new("sp_BookAppointment", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PatientCode", dto.PatientCode);
            cmd.Parameters.AddWithValue("@DoctorCode", dto.DoctorCode);
            cmd.Parameters.AddWithValue("@AppointmentDate", dto.AppointmentDate);

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        // Cancels an appointment in the database
        public async Task CancelAppointmentAsync(int appointmentId)
        {
            using SqlConnection con = _dbHelper.GetConnection();

            using SqlCommand cmd = new("sp_CancelAppointment", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        // Retrieves upcoming appointments from the database
        public async Task<List<Appointment>> GetUpcomingAppointmentsAsync()
        {
            List<Appointment> appointments = new();

            using SqlConnection con = _dbHelper.GetConnection();

            await con.OpenAsync();

            await UpdateCompletedAppointmentsAsync(con);

            using SqlCommand cmd = new("sp_GetUpcomingAppointments", con);

            cmd.CommandType = CommandType.StoredProcedure;

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                appointments.Add(MapAppointment(reader));
            }

            return appointments;
        }

        // Retrieves appointments for a specific doctor
        public async Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorCode)
        {
            List<Appointment> appointments = new();

            using SqlConnection con = _dbHelper.GetConnection();

            await con.OpenAsync();

            await UpdateCompletedAppointmentsAsync(con);

            using SqlCommand cmd = new("sp_GetDoctorAppointments", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DoctorCode", doctorCode);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                appointments.Add(MapAppointment(reader));
            }

            return appointments;
        }

        // Retrieves appointments for a specific patient
        public async Task<List<Appointment>> GetPatientAppointmentsAsync(int patientCode)
        {
            List<Appointment> appointments = new();

            using SqlConnection con = _dbHelper.GetConnection();

            await con.OpenAsync();

            await UpdateCompletedAppointmentsAsync(con);

            using SqlCommand cmd = new("sp_GetPatientAppointments", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientCode", patientCode);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                appointments.Add(MapAppointment(reader));
            }

            return appointments;
        }

        // Updates appointments marked as completed based on date
        private async Task UpdateCompletedAppointmentsAsync(SqlConnection con)
        {
            using SqlCommand cmd = new("sp_UpdateCompletedAppointments", con);

            cmd.CommandType = CommandType.StoredProcedure;

            await cmd.ExecuteNonQueryAsync();
        }

        // Maps a data reader row to an Appointment model
        private Appointment MapAppointment(SqlDataReader reader)
        {
            return new Appointment
            {
                AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                PatientCode = Convert.ToInt32(reader["PatientCode"]),
                DoctorCode = Convert.ToInt32(reader["DoctorCode"]),
                AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                AppointmentStatus = reader["AppointmentStatus"].ToString()!,

                CancelledAt =
                    reader["CancelledAt"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(reader["CancelledAt"])
            };
        }



        public async Task<PatientEmailDetails?> GetPatientEmailDetailsAsync(int patientCode)
        {
            using SqlConnection con = _dbHelper.GetConnection();

            using SqlCommand cmd =
                new("sp_GetPatientEmailDetails", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PatientCode", patientCode);

            await con.OpenAsync();

            using SqlDataReader reader =
                await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new PatientEmailDetails
                {
                    FullName = reader["FullName"].ToString()!,
                    Email = reader["Email"].ToString()!
                };
            }

            return null;
        }
    }
}