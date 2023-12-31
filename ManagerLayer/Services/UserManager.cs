﻿using CommonLayer;
using ManagerLayer.Interfaces;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ManagerLayer.Services
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public UserRegistrationModel Registration(UserRegistrationModel model)
        {
            try
            {
                return userRepository.Registration(model);
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
                return userRepository.Login(login);
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
                return userRepository.GetAllRecords();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        
    }
}
