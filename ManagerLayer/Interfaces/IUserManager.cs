using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface IUserManager
    {
        public UserRegistrationModel Registration(UserRegistrationModel model);
    }
}
