using CommonLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
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
                    SqlCommand command = new SqlCommand("InsertUsers", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("FirstName", model.FirstName);
                    command.Parameters.AddWithValue("LastName", model.LastName);
                    command.Parameters.AddWithValue("Email", model.Email);
                    command.Parameters.AddWithValue("Password", model.Password);
                    command.Parameters.AddWithValue("Mobile", model.Mobile);
                    command.Parameters.AddWithValue("Gender", model.Gender);
                    command.Parameters.AddWithValue("RoleId", model.RoleId);
                    command.Parameters.AddWithValue("CreatedAt",DateTime.Now);
                    command.Parameters.AddWithValue("ModifiedAt",DateTime.Now);
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
        public UserRegistrationModel Login(UserLoginModel login)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                using (con)
                {
                    SqlCommand command = new SqlCommand("UserLogin", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Email", login.Email);
                    command.Parameters.AddWithValue("Password", login.Password);
                    con.Open();
                    //var res=command.ExecuteNonQuery();
                    UserRegistrationModel model = new UserRegistrationModel();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        model.UserId = reader.GetInt32(0);
                        model.FirstName = reader.GetString(1);
                        model.LastName = reader.GetString(2);
                        model.Email = reader.GetString(3);
                        model.Password = reader.GetString(4);
                        model.Mobile = reader.GetInt64(5);
                        model.Gender = reader.GetString(6);
                        model.RoleId = reader.GetInt32(7);
                    }
                    return model;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public List<UserRegistrationModel> GetAllRecords()
        {
            try
            {
               List<UserRegistrationModel> list = new List<UserRegistrationModel>();
                SqlConnection con = new SqlConnection(connectionString);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("GetRecords", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UserRegistrationModel model = new UserRegistrationModel();
                        model.UserId = reader.GetInt32(0);
                        model.FirstName = reader.GetString(1);
                        model.LastName = reader.GetString(2);
                        model.Email = reader.GetString(3);
                        model.Password = reader.GetString(4);
                        model.Mobile = reader.GetInt64(5);
                        model.Gender = reader.GetString(6);
                        model.RoleId = reader.GetInt32(7);
                        list.Add(model);
                    }
                }
                con.Close();
                return list;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        
    }
}