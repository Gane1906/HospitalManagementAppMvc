using CommonLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public DoctorRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("HospitalDB");
            this.configuration = configuration;
        }
        public DoctorModel AddDoctorDetails(DoctorModel doctor)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("InsertDoctor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ProfilePic", doctor.ProfilePic);
                    cmd.Parameters.AddWithValue("Qualification", doctor.Qualification);
                    cmd.Parameters.AddWithValue("Specialization", doctor.Specialization);
                    cmd.Parameters.AddWithValue("Experience", doctor.Experience);
                    cmd.Parameters.AddWithValue("IsTrash", doctor.IsTrash);
                    cmd.Parameters.AddWithValue("CreatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("ModifiedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("UserId", doctor.UserId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return doctor;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DoctorModel GetDoctorById(int doctorId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (con)
            {
                SqlCommand cmd = new SqlCommand("GetDoctorById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("DoctorId", doctorId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DoctorModel doctor = new DoctorModel();
                    doctor.DoctorId = reader.GetInt32(0);
                    doctor.ProfilePic = reader.GetString(1);
                    doctor.Qualification = reader.GetString(2);
                    doctor.Specialization = reader.GetString(3);
                    doctor.Experience = reader.GetInt32(4);
                    doctor.CreatedAt = reader.GetDateTime(6);
                    doctor.ModifiedAt = reader.GetDateTime(7);
                    doctor.UserId = reader.GetInt32(8);
                    con.Close();
                    return doctor;
                }
                return null;
            }
        }
        public DoctorModel GetDoctorByUserId(int userId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (con)
            {
                SqlCommand cmd = new SqlCommand("GetByUSerId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("userId", userId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DoctorModel doctor = new DoctorModel();
                    doctor.DoctorId = reader.GetInt32(0);
                    doctor.ProfilePic = reader.GetString(1);
                    doctor.Qualification = reader.GetString(2);
                    doctor.Specialization = reader.GetString(3);
                    doctor.Experience = reader.GetInt32(4);
                    doctor.CreatedAt = reader.GetDateTime(6);
                    doctor.ModifiedAt = reader.GetDateTime(7);
                    doctor.UserId = reader.GetInt32(8);
                    con.Close();
                    return doctor;
                }
                return null;
            }
        }
        public List<DoctorModel> GetAllDoctors()
        {
            List<DoctorModel> list = new List<DoctorModel>();
            SqlConnection con = new SqlConnection(connectionString);
            using (con)
            {
                SqlCommand cmd = new SqlCommand("GetAllDoctors", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader reader=cmd.ExecuteReader();
                while (reader.Read())
                {
                    DoctorModel doctor = new DoctorModel();
                    doctor.DoctorId = reader.GetInt32(0);
                    doctor.ProfilePic = reader.GetString(1);
                    doctor.Qualification = reader.GetString(2);
                    doctor.Specialization = reader.GetString(3);
                    doctor.Experience = reader.GetInt32(4);
                    doctor.CreatedAt = reader.GetDateTime(6);
                    doctor.ModifiedAt = reader.GetDateTime(7);
                    doctor.UserId = reader.GetInt32(8);
                    list.Add(doctor);
                }
                return list;
            }
        }
    }
}
