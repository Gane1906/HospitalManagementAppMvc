using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRepository
    {
        public UserRegistrationModel Registration(UserRegistrationModel model);
        public UserRegistrationModel Login(UserLoginModel login);
        public List<UserRegistrationModel> GetAllRecords();
        
    }
}
