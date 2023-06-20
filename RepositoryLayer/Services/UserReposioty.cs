using CommonLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserReposioty : IUserRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public UserReposioty(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("HospitalDB");
            this.configuration = configuration;
        }
        public UserRegistrationModel Registration(UserRegistrationModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand command = new SqlCommand("InsertUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("FirstName", model.FirstName);
                    command.Parameters.AddWithValue("LastName", model.LastName);
                    command.Parameters.AddWithValue("Email", model.Email);
                    command.Parameters.AddWithValue("Password", model.Password);
                    command.Parameters.AddWithValue("Mobile", model.Mobile);
                    command.Parameters.AddWithValue("Gender", model.Gender);
                    command.Parameters.AddWithValue("Dob", model.Dob);
                    command.Parameters.AddWithValue("RoleId", model.RoleId);
                    command.Parameters.AddWithValue("CreatedAt",model.CreatedAt);
                    command.Parameters.AddWithValue("ModifiedAt",model.ModifiedAt);
                    command.Parameters.AddWithValue("IsTrash",model.IsTrash);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return model;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}