using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class UserRegistrationModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Mobile { get; set; }
        public string Gender { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsTrash { get; set; }
    }
}