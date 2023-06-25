using CommonLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace RepositoryLayer.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public PatientRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("HospitalDB");
            this.configuration = configuration;
        }
        public PatientModel AddPatientDetails(PatientModel patient)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("InsertPatients", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ProfilePic", patient.ProfilePic);
                    cmd.Parameters.AddWithValue("Concern", patient.Concern);
                    cmd.Parameters.AddWithValue("Gender", patient.Gender);
                    cmd.Parameters.AddWithValue("Age", patient.Age);
                    cmd.Parameters.AddWithValue("MedicalHistory", patient.MedicalHiostory);
                    cmd.Parameters.AddWithValue("IsTrash", patient.IsTrash);
                    cmd.Parameters.AddWithValue("CreatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("ModifiedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("UserId", patient.UserId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return patient;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public PatientModel GetPatientbyId(int patientId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (con)
            {
                PatientModel patient = new PatientModel();
                SqlCommand cmd = new SqlCommand("GetPateintbyId", con);
                cmd.Parameters.AddWithValue("PatientId", patientId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    patient.PatientId = reader.GetInt32("PatientId");
                    patient.ProfilePic = reader.GetString("ProfilePic");
                    patient.Concern = reader.GetString(2);
                    patient.Gender = reader.GetString(3);
                    patient.Age = reader.GetInt32(4);
                    patient.MedicalHiostory = reader.GetString(5);
                    patient.CreatedAt = reader.GetDateTime(7);
                    patient.ModifiedAt = reader.GetDateTime(8);
                    patient.UserId = reader.GetInt32(9);
                    return patient;
                }
                return null;
            }
        }
        public PatientModel GetPatientByUserId(int userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                using (con)
                {
                    PatientModel patient = new PatientModel();
                    SqlCommand cmd = new SqlCommand("GetPatientByUserId", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("userId", userId);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        patient.PatientId = reader.GetInt32("PatientId");
                        patient.ProfilePic = reader.GetString("ProfilePic");
                        patient.Concern = reader.GetString(2);
                        patient.Gender = reader.GetString(3);
                        patient.Age = reader.GetInt32(4);
                        patient.MedicalHiostory = reader.GetString(5);
                        patient.CreatedAt = reader.GetDateTime(7);
                        patient.ModifiedAt = reader.GetDateTime(8);
                        patient.UserId = reader.GetInt32(9);
                        return patient;
                    }
                    return null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public List<PatientModel> GetAllPatients()
        {
            try
            {
                List<PatientModel> list = new List<PatientModel>();
                SqlConnection con = new SqlConnection(connectionString);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("GetAllPatients", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PatientModel patient = new PatientModel();
                        patient.PatientId = reader.GetInt32(0);
                        patient.ProfilePic = reader.GetString(1);
                        patient.Concern = reader.GetString(2);
                        patient.Gender = reader.GetString(3);
                        patient.Age = reader.GetInt32(4);
                        patient.MedicalHiostory = reader.GetString(5);
                        patient.CreatedAt = reader.GetDateTime(7);
                        patient.ModifiedAt = reader.GetDateTime(8);
                        patient.UserId = reader.GetInt32(9);
                        list.Add(patient);
                    }
                    con.Close();
                    return list;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
